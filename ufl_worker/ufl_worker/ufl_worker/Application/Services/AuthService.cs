using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Entities;
using ufl_worker.Core.Interfaces;

namespace ufl_worker.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly TokenService _tokenService;

        public AuthService(IUserRepository userRepository,
                           IEmployeeRepository employeeRepository,
                           TokenService tokenService)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _tokenService = tokenService;
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            // Crear empleado
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CI = dto.CI,
                Cellphone = dto.Cellphone,
                Salary = dto.Salary,
                BranchId = dto.BranchId,
                PositionId = dto.PositionId
            };
            await _employeeRepository.AddAsync(employee);

            // Crear usuario con la referencia al empleado
            var user = new User
            {
                Username = dto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password), // Hashear contraseña
                Email = dto.Email,
                RolId = dto.RolId,
                EmployeeId = employee.Id // Asignar el empleado creado
            };
            await _userRepository.AddAsync(user);
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(u => u.Username == dto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return null; // Usuario no encontrado o contraseña incorrecta
            }

            // Generar el token JWT
            return _tokenService.GenerateToken(user.Id, user.Username, user.RolId);
        }
    }
}

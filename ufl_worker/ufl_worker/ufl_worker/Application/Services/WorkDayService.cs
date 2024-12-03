using ufl_worker.Application.DTOs;
using ufl_worker.Application.Mappers;
using ufl_worker.Core.Interfaces;
using ufl_worker.Infrastructure.Repositories;
using ufl_worker.Models;

namespace ufl_worker.Application.Services
{
    public class WorkDayService
    {
        private readonly IWorkDayRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly List<DateTime> _holidays;

        public WorkDayService(
            IWorkDayRepository repository,
            IEmployeeRepository employeeRepository,
            IConfiguration configuration)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;

            // Leer los días feriados desde el archivo de configuración
            var holidaysConfig = configuration.GetSection("Holidays").Get<List<string>>();
            _holidays = holidaysConfig?.Select(h => DateTime.Parse(h)).ToList() ?? new List<DateTime>();
        }

        public async Task<IEnumerable<WorkDayDto>> GetAllAsync()
        {
            var workDays = await _repository.GetAllAsync();
            return workDays.Select(w => w.ToDto());
        }

        public async Task<WorkDayDto?> GetByIdAsync(int id)
        {
            var workDay = await _repository.GetByIdAsync(id);
            return workDay?.ToDto();
        }

        public async Task AddAsync(WorkDayDto dto)
        {
            var workDay = dto.ToEntity();
            await _repository.AddAsync(workDay);
        }

        public async Task UpdateAsync(WorkDayDto dto)
        {
            var workDay = dto.ToEntity();
            await _repository.UpdateAsync(workDay);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // --------------------------------------------------
        public async Task ValidateWorkDayAsync(ValidateWorkDayDto dto)
        {
            var workDay = await _repository.GetByIdAsync(dto.WorkDayId);
            if (workDay == null)
            {
                throw new Exception("WorkDay not found.");
            }

            workDay.IsCounted = dto.IsCounted;
            await _repository.UpdateAsync(workDay);
        }
        public async Task StartWorkDayAsync(StartWorkDayDto dto)
        {
            var workDay = new WorkDay
            {
                EmployeeId = dto.EmployeeId,
                Start = DateTime.Now,
                IsCounted = false
            };

            await _repository.AddAsync(workDay);
        }

        public async Task EndWorkDayAsync(EndWorkDayDto dto)
        {
            var workDay = await _repository.GetByIdAsync(dto.WorkDayId);
            if (workDay == null || workDay.End != null)
            {
                throw new Exception("WorkDay not found or already ended.");
            }

            // Marcar fin y guardar GPS
            workDay.End = DateTime.Now;
            workDay.Lat = dto.Lat;
            workDay.Lon = dto.Lon;

            // Calcular salario
            var employee = await _employeeRepository.GetByIdAsync(workDay.EmployeeId);
            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            workDay.Salary = CalculateSalary(workDay.Start, workDay.End.Value, employee.Salary);
            workDay.IsCounted = false;

            await _repository.UpdateAsync(workDay);
        }

        private decimal CalculateSalary(DateTime start, DateTime end, decimal hourlyRate)
        {
            decimal totalSalary = 0;
            var current = start;

            while (current < end)
            {
                // Determinar la hora límite de pago normal
                var normalEndTime = GetNormalEndTime(current);

                // Verificar si es feriado
                bool isHoliday = _holidays.Contains(current.Date);

                // Calcular tiempo trabajado en el periodo actual
                var periodEnd = current.Date == end.Date && end < normalEndTime ? end : normalEndTime;
                if (periodEnd > end) periodEnd = end;

                var workedHours = (decimal)(periodEnd - current).TotalHours;

                if (isHoliday || current > normalEndTime) // Pago doble
                {
                    totalSalary += workedHours * hourlyRate * 2;
                }
                else // Pago normal
                {
                    totalSalary += workedHours * hourlyRate;
                }

                current = periodEnd;
            }

            return totalSalary;
        }

        private DateTime GetNormalEndTime(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                return date.Date.AddHours(12); // Sábados, medio día
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return date.Date; // Domingos, normalmente no se trabaja
            }
            else
            {
                return date.Date.AddHours(18); // Lunes a viernes, 6:00 PM
            }
        }

    }
}

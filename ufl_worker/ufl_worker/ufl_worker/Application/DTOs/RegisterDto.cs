namespace ufl_worker.Application.DTOs
{
    public class RegisterDto
    {
        // Datos del usuario
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }

        // Datos del empleado
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CI { get; set; }
        public string Cellphone { get; set; }
        public decimal Salary { get; set; }
        public int BranchId { get; set; }
        public int PositionId { get; set; }
    }
}

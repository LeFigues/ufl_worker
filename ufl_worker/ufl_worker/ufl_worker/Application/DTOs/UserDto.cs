namespace ufl_worker.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        public int? EmployeeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

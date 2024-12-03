namespace ufl_worker.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CI { get; set; }
        public string Cellphone { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? FireDate { get; set; }
        public decimal Salary { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public int PositionId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

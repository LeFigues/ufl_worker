namespace ufl_worker.Application.DTOs
{
    public class WorkDayDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public decimal Salary { get; set; }
        public bool IsCounted { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }
        public int EmployeeId { get; set; }
        public int? PaymentSalarieId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

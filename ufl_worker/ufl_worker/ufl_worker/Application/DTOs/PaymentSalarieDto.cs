namespace ufl_worker.Application.DTOs
{
    public class PaymentSalarieDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfPayment { get; set; }
        public double TotalHours { get; set; }
        public decimal? ExtraAmount { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

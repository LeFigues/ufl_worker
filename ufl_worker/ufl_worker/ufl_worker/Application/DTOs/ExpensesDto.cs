namespace ufl_worker.Application.DTOs
{
    public class ExpensesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public DateTime RegisterAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}

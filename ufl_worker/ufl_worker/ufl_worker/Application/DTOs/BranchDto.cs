namespace ufl_worker.Application.DTOs
{
    public class BranchDto
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string? BranchCellphone { get; set; }
        public int BusinessId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

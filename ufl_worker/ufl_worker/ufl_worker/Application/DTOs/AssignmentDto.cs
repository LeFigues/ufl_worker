namespace ufl_worker.Application.DTOs
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Register { get; set; }
        public DateTime? Expired { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

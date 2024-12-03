namespace ufl_worker.Application.DTOs
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}

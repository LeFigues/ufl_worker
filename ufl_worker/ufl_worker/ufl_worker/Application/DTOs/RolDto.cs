namespace ufl_worker.Application.DTOs
{
    public class RolDto
    {
        public int Id { get; set; }
        public string RolName { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}

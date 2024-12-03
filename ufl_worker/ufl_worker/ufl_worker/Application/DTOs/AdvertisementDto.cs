namespace ufl_worker.Application.DTOs
{
    public class AdvertisementDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateOnly? Date { get; set; }
        public int UserId { get; set; }
        public DateTime RegisterAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}

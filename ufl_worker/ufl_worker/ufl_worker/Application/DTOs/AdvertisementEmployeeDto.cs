namespace ufl_worker.Application.DTOs
{
    public class AdvertisementEmployeeDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? ReadAt { get; set; }
        public bool IsChecked { get; set; }
    }
}

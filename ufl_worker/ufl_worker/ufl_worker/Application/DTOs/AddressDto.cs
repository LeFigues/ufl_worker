namespace ufl_worker.Application.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string Direction { get; set; }
        public string? Reference { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public int EmployeeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

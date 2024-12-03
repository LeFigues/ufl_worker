namespace ufl_worker.Application.DTOs
{
    public class AssignmentEmployeeDto
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? ReadAt { get; set; }
        public DateTime? TaskStart { get; set; }
        public DateTime? TaskFinish { get; set; }
        public bool IsFinished { get; set; }
        public string? ResultInformation { get; set; }
        public bool IsDeleted { get; set; }
    }
}

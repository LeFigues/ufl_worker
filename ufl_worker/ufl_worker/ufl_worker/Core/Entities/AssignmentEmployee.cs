using System.ComponentModel.DataAnnotations;
using ufl_worker.Models;

namespace ufl_worker.Core.Entities
{
    public class AssignmentEmployee
    {
        [Key]
        public int Id { get; set; }

        public DateTime? ReadAt { get; set; } 
        public DateTime? TaskStart { get; set; }
        public DateTime? TaskFinish { get; set; }
        public bool IsFinished { get; set; }
        public string? ResultInformation { get; set; }

        public int AssignmentId { get; set; }
        public Assignment? Assignment { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public bool IsDeleted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ufl_worker.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string PositionName { get; set; }
        public string? Description { get; set; }

        public ICollection<Employee>? Employees { get; set; }
        public bool IsDeleted { get; set; }
    }
}

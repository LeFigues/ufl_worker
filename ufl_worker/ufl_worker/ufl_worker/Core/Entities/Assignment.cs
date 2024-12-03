using System.ComponentModel.DataAnnotations;
using ufl_worker.Core.Entities;

namespace ufl_worker.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        public DateTime Register { get; set; } = DateTime.Now;
        public DateTime? Expired { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
        public bool IsDeleted { get; set; }

        // Encapsulación para adherirnos a la arquitectura hexagonal
        private ICollection<AssignmentEmployee>? _assignmentEmployees;
        public IReadOnlyCollection<AssignmentEmployee>? AssignmentEmployees => _assignmentEmployees?.ToList();

        public void AddAssignmentEmployee(AssignmentEmployee assignmentEmployee)
        {
            _assignmentEmployees ??= new List<AssignmentEmployee>();
            _assignmentEmployees.Add(assignmentEmployee);
        }
    }

}

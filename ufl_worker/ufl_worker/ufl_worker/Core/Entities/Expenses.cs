using System.ComponentModel.DataAnnotations;
using ufl_worker.Models;

namespace ufl_worker.Core.Entities
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime RegisterAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;
using ufl_worker.Core.Entities;

namespace ufl_worker.Models
{
    public class PaymentSalarie
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime DateOfPayment { get; set; } = DateTime.Now;
        public double TotalHours { get; set; }
        public decimal? ExtraAmount { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public ICollection<WorkDay>? WorkDays { get; set; }
        public bool IsDeleted { get; set; }

    }
}

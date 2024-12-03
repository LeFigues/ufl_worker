using System.ComponentModel.DataAnnotations;

namespace ufl_worker.Models
{
    public class WorkDay
    {
        [Key]
        public int Id { get; set; }

        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime? End { get; set; }
        public decimal Salary { get; set; } = 0;
        public bool IsCounted { get; set; }
        public string? Lat { get; set; }
        public string? Lon { get; set; }


        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int? PaymentSalarieId { get; set; }
        public PaymentSalarie? PaymentSalarie { get; set; }

        public bool IsDeleted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using ufl_worker.Models;

namespace ufl_worker.Core.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string AddressName { get; set; }

        [Required, MaxLength(250)]
        public string Direction { get; set; }

        [MaxLength(250)]
        public string? Reference { get; set; }

        public double? Lat { get; set; }
        public double? Long { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public bool IsDeleted { get; set; }
    }
}

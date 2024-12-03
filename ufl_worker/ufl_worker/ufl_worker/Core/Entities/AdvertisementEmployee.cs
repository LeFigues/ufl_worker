using System.ComponentModel.DataAnnotations;
using ufl_worker.Models;

namespace ufl_worker.Core.Entities
{
    public class AdvertisementEmployee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AdvertisementId { get; set; }
        public Advertisement? Advertisement { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public DateTime? ReadAt { get; set; }
        public bool IsChecked { get; set; }
    }

}

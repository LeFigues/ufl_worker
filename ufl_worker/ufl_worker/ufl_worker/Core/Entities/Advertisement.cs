using System.ComponentModel.DataAnnotations;
using ufl_worker.Core.Entities;

namespace ufl_worker.Models
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string? Type { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateOnly? Date { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        // Encapsulación para adherirnos a la arquitectura hexagonal
        private ICollection<AdvertisementEmployee>? _advertisementEmployees;
        public IReadOnlyCollection<AdvertisementEmployee>? AdvertisementEmployees => _advertisementEmployees?.ToList();

        public void AddAdvertisementEmployee(AdvertisementEmployee advertisementEmployee)
        {
            _advertisementEmployees ??= new List<AdvertisementEmployee>();
            _advertisementEmployees.Add(advertisementEmployee);
        }

        public DateTime RegisterAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using ufl_worker.Core.Entities;

namespace ufl_worker.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        public string RolName { get; set; }
        public string? Description { get; set; }

        public ICollection<User>? Users { get; set; }
        public bool IsDeleted { get; set; }
    }
}

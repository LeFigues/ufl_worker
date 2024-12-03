using System.ComponentModel.DataAnnotations;

namespace ufl_worker.Models
{
    public class Business
    {
        [Key]
        public int Id { get; set; }
        public int Ufl_ID { get; set; }
        public string BusinessName { get; set; }
        public ICollection<Branch>? Branches { get; set; }
        public bool IsDeleted { get; set; }
    }
}

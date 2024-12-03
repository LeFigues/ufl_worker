using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;
using ufl_worker.Core.Entities;

namespace ufl_worker.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string? BranchCellphone { get; set; }

        public int BusinessId { get; set; }
        public Business? Business { get; set; }

        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
        public ICollection<Expenses>? Expenses { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; }

    [Required, MaxLength(255)]
    public string Password { get; set; }

    [Required, MaxLength(150)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public int RolId { get; set; }
    public Rol? Rol { get; set; }

    public int? EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public bool IsDeleted { get; set; }

    // Relaciones encapsuladas con ICollection<>
    private ICollection<Advertisement>? _advertisements;
    public IReadOnlyCollection<Advertisement>? Advertisements => _advertisements?.ToList();

    private ICollection<Assignment>? _assignments;
    public IReadOnlyCollection<Assignment>? Assignments => _assignments?.ToList();

    private ICollection<Expenses>? _expenses;
    public IReadOnlyCollection<Expenses>? Expenses => _expenses?.ToList();


    // Métodos para agregar relaciones (para adherirse a la arquitectura hexagonal)
    public void AddAdvertisement(Advertisement advertisement)
    {
        _advertisements ??= new List<Advertisement>();
        _advertisements.Add(advertisement);
    }

    public void AddAssignment(Assignment assignment)
    {
        _assignments ??= new List<Assignment>();
        _assignments.Add(assignment);
    }

    public void AddExpense(Expenses expense)
    {
        _expenses ??= new List<Expenses>();
        _expenses.Add(expense);
    }

}

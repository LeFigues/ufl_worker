using System.ComponentModel.DataAnnotations;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }

    [Required, MaxLength(20)]
    public string CI { get; set; }

    [Required, MaxLength(15)]
    public string Cellphone { get; set; }

    public DateTime HireDate { get; set; } = DateTime.Now;
    public DateTime? FireDate { get; set; }
    public decimal Salary { get; set; }

    [Required]
    public int UserId { get; set; }
    public User? User { get; set; }

    [Required]
    public int BranchId { get; set; }
    public Branch? Branch { get; set; }

    [Required]
    public int PositionId { get; set; }
    public Position? Position { get; set; }

    // Relaciones encapsuladas con ICollection<>
    private ICollection<Address>? _addresses;
    public IReadOnlyCollection<Address>? Addresses => _addresses?.ToList();

    private ICollection<AdvertisementEmployee>? _advertisementEmployees;
    public IReadOnlyCollection<AdvertisementEmployee>? AdvertisementEmployees => _advertisementEmployees?.ToList();

    private ICollection<AssignmentEmployee>? _assignmentEmployees;
    public IReadOnlyCollection<AssignmentEmployee>? AssignmentEmployees => _assignmentEmployees?.ToList();

    private ICollection<PaymentSalarie>? _paymentSalaries;
    public IReadOnlyCollection<PaymentSalarie>? PaymentSalaries => _paymentSalaries?.ToList();

    private ICollection<WorkDay>? _workDays;
    public IReadOnlyCollection<WorkDay>? WorkDays => _workDays?.ToList();

    public bool IsDeleted { get; set; }

    // Métodos para agregar relaciones (para adherirse a la arquitectura hexagonal)
    public void AddAddress(Address address)
    {
        _addresses ??= new List<Address>();
        _addresses.Add(address);
    }

    public void AddAdvertisementEmployee(AdvertisementEmployee advertisementEmployee)
    {
        _advertisementEmployees ??= new List<AdvertisementEmployee>();
        _advertisementEmployees.Add(advertisementEmployee);
    }

    public void AddAssignmentEmployee(AssignmentEmployee assignmentEmployee)
    {
        _assignmentEmployees ??= new List<AssignmentEmployee>();
        _assignmentEmployees.Add(assignmentEmployee);
    }

    public void AddPaymentSalarie(PaymentSalarie paymentSalarie)
    {
        _paymentSalaries ??= new List<PaymentSalarie>();
        _paymentSalaries.Add(paymentSalarie);
    }

    public void AddWorkDay(WorkDay workDay)
    {
        _workDays ??= new List<WorkDay>();
        _workDays.Add(workDay);
    }
}

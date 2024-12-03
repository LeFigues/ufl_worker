using Microsoft.EntityFrameworkCore;
using ufl_worker.Core.Entities;
using ufl_worker.Models;

namespace ufl_worker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // DbSets para cada entidad
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementEmployee> AdvertisementEmployees { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentEmployee> AssignmentEmployees { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<PaymentSalarie> PaymentSalaries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación uno a uno entre Employee y User
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<User>(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Branch y Employee
            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Employees)
                .WithOne(e => e.Branch)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Branch y Assignment
            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Assignments)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Branch y Expenses
            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Expenses)
                .WithOne(e => e.Branch)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Business y Branch
            modelBuilder.Entity<Business>()
                .HasMany(b => b.Branches)
                .WithOne(br => br.Business)
                .HasForeignKey(br => br.BusinessId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Position y Employee
            modelBuilder.Entity<Position>()
                .HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Rol y User
            modelBuilder.Entity<Rol>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Rol)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Advertisement y AdvertisementEmployee
            modelBuilder.Entity<Advertisement>()
                .HasMany(a => a.AdvertisementEmployees)
                .WithOne(ae => ae.Advertisement)
                .HasForeignKey(ae => ae.AdvertisementId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Assignment y AssignmentEmployee
            modelBuilder.Entity<Assignment>()
                .HasMany(a => a.AssignmentEmployees)
                .WithOne(ae => ae.Assignment)
                .HasForeignKey(ae => ae.AssignmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Employee y AdvertisementEmployee
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AdvertisementEmployees)
                .WithOne(ae => ae.Employee)
                .HasForeignKey(ae => ae.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Employee y AssignmentEmployee
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AssignmentEmployees)
                .WithOne(ae => ae.Employee)
                .HasForeignKey(ae => ae.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Employee y Address
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Addresses)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Employee y PaymentSalarie
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.PaymentSalaries)
                .WithOne(ps => ps.Employee)
                .HasForeignKey(ps => ps.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Employee y WorkDay
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkDays)
                .WithOne(wd => wd.Employee)
                .HasForeignKey(wd => wd.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre PaymentSalarie y WorkDay
            modelBuilder.Entity<PaymentSalarie>()
                .HasMany(ps => ps.WorkDays)
                .WithOne(wd => wd.PaymentSalarie)
                .HasForeignKey(wd => wd.PaymentSalarieId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración adicional para propiedades únicas o índices (opcional)
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.CI)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }
}

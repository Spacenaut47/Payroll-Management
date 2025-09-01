using Microsoft.EntityFrameworkCore;
using PayrollManagement.Core.Entities;

namespace PayrollManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Payroll> Payrolls => Set<Payroll>();
        public DbSet<PayrollItem> PayrollItems => Set<PayrollItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(b =>
            {
                b.HasIndex(u => u.Username).IsUnique();
                b.Property(u => u.Username).IsRequired();
                b.Property(u => u.PasswordHash).IsRequired();
            });

            modelBuilder.Entity<Employee>(b =>
            {
                b.Property(e => e.FirstName).IsRequired();
                b.Property(e => e.LastName).IsRequired();
                b.HasOne(e => e.Department).WithMany().HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Department>(b =>
            {
                b.Property(d => d.Name).IsRequired();
            });

            modelBuilder.Entity<Payroll>(b =>
            {
                b.HasOne(p => p.Employee).WithMany().HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PayrollItem>(b =>
            {
                b.HasOne(pi => pi.Payroll).WithMany(p => p.Items).HasForeignKey(pi => pi.PayrollId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

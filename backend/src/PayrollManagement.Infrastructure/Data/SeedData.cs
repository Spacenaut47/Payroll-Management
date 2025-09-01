using PayrollManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using PayrollManagement.Core.Interfaces;
using PayrollManagement.Infrastructure.Data;
using PayrollManagement.Core.Enums;
using PayrollManagement.Core.Common;

namespace PayrollManagement.Infrastructure.Data
{
    public static class SeedData
    {
        public static void EnsureSeedData(ApplicationDbContext db, IPasswordService passwordService)
        {
            if (!db.Users.Any())
            {
                db.Users.Add(new User
                {
                    Username = "admin",
                    PasswordHash = passwordService.HashPassword("Admin@123"),
                    FullName = "Administrator",
                    Email = "admin@example.com",
                    Role = UserRole.Admin
                });

                db.Users.Add(new User
                {
                    Username = "user",
                    PasswordHash = passwordService.HashPassword("User@123"),
                    FullName = "Normal User",
                    Email = "user@example.com",
                    Role = UserRole.User
                });
            }

            if (!db.Departments.Any())
            {
                db.Departments.Add(new Department { Name = "Engineering", Description = "Engineering Dept" });
                db.Departments.Add(new Department { Name = "HR", Description = "Human Resources" });
            }

            if (!db.Employees.Any())
            {
                db.Employees.Add(new Employee
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    DateOfJoining = DateTime.UtcNow.AddYears(-2),
                    Salary = 50000m,
                    DepartmentId = 1
                });
            }

            db.SaveChanges();
        }
    }
}

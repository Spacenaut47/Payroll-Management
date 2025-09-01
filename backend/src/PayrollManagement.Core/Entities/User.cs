using PayrollManagement.Core.Enums;

namespace PayrollManagement.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; } = UserRole.User;
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}

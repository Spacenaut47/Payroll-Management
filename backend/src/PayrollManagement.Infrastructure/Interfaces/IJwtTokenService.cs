using PayrollManagement.Core.Entities;

namespace PayrollManagement.Core.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}

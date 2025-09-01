namespace PayrollManagement.Core.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hash, string password);
    }
}

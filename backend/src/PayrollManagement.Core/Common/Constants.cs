namespace PayrollManagement.Core.Common;

public static class Constants
{
    public static class Roles
    {
        public const string Employee = "Employee";
        public const string Manager = "Manager";
        public const string HR = "HR";
        public const string Admin = "Admin";
        public const string SuperAdmin = "SuperAdmin";
    }

    public static class Claims
    {
        public const string UserId = "userId";
        public const string Email = "email";
        public const string Role = "role";
        public const string EmployeeId = "employeeId";
    }

    public static class PayrollItems
    {
        public const string Allowance = "Allowance";
        public const string Deduction = "Deduction";
        public const string Tax = "Tax";
        public const string Bonus = "Bonus";
        public const string Overtime = "Overtime";
    }

    public static class DefaultValues
    {
        public const int DefaultPageSize = 10;
        public const int MaxPageSize = 100;
        public const decimal DefaultOvertimeRate = 1.5m;
        public const decimal DefaultTaxRate = 0.20m;
    }

    public static class ErrorMessages
    {
        public const string NotFound = "Resource not found";
        public const string Unauthorized = "You are not authorized to perform this action";
        public const string InvalidCredentials = "Invalid email or password";
        public const string EmailAlreadyExists = "Email address is already in use";
        public const string InvalidData = "Invalid data provided";
        public const string InternalServerError = "An internal server error occurred";
    }
}
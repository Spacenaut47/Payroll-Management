namespace PayrollManagement.Core.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public T? Data { get; set; }
        public string? Error { get; set; }
    }
}

namespace EmployeeApi.Application.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public ApiResponse SuccessResponse(object? data, string? message = null) =>
            new() { Success = true, Data = data, Message = message };

        public ApiResponse FailureResponse(string message) =>
            new() { Success = false, Message = message };

        public ApiResponse SuccessResponse() =>
            new() { Success = true, Message = string.Empty };
    }
}


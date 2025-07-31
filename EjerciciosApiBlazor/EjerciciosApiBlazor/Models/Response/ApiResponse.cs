namespace EjerciciosApiBlazor.Models.Response;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public int? StatusCode { get; set; }

    public static ApiResponse<T> Ok(T data, string message = "Éxito", int? statusCode = 200)
        => new() { Success = true, Message = message, Data = data, StatusCode = statusCode };

    public static ApiResponse<T> Fail(string message = "Error desconocido", int? statusCode = 500)
        => new() { Success = false, Message = message, Data = default, StatusCode = statusCode };
}

namespace EjerciciosApiBlazor.Helpers;

using System.Net.Http;
using System.Text.Json;

public static class ApiErrorHelper
{
    public static async Task<string> ExtractErrorMessageAsync(HttpResponseMessage response)
    {
        var statusCode = (int)response.StatusCode;
        var content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(content))
            return $"Error {statusCode}: respuesta vacía";

        // Intentar parsear como JSON con estructura { "error": "mensaje" }
        try
        {
            var errorObj = JsonSerializer.Deserialize<Dictionary<string, string>>(content);
            if (errorObj != null && errorObj.TryGetValue("error", out var errorMessage))
            {
                return $"Error {statusCode}: {errorMessage}";
            }
        }
        catch
        {
            // Ignorar si no es JSON
        }

        // Devolver contenido plano si no es JSON o no tiene "error"
        return $"Error {statusCode}: {content}";
    }
}


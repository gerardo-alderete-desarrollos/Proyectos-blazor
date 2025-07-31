using EjerciciosApiBlazor.Helpers;
using EjerciciosApiBlazor.Models.Entities;
using EjerciciosApiBlazor.Models.Response;
using System.Text.Json;

namespace EjerciciosApiBlazor.Services;

public class BookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://openlibrary.org/");

    }

    public async Task<ApiResponse<List<BookDoc>>> SearchBooksByTitleAsync(string title)
    {
        try
        {
            var response = await _httpClient.GetAsync($"search.json?title={Uri.EscapeDataString(title)}");
            var statusCode = (int)response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await ApiErrorHelper.ExtractErrorMessageAsync(response);
                return new ApiResponse<List<BookDoc>>
                {
                    Success = false,
                    Message = errorMessage,
                    StatusCode = statusCode,
                    Data = null
                };
            }

            var result = await response.Content.ReadFromJsonAsync<BookSearchResponse>();
            var books = result?.Docs ?? new();

            return new ApiResponse<List<BookDoc>>
            {
                Success = true,
                Message = $"Se encontraron {books.Count} libros.",
                StatusCode = statusCode,
                Data = books
            };
        }
        catch (Exception ex)
        {
            return ApiResponse<List<BookDoc>>.Fail($"Excepción: {ex.Message}");
        }
    }
}

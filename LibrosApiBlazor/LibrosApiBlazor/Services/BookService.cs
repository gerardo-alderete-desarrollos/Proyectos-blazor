using System.Net.Http;
using System.Text.Json;

public class BookService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly string _apiUrl;

    public BookService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _apiUrl = _configuration["Api:urlBase"] ?? "https://localhost:5001/api/books";
    }

    public async Task<List<Object>> GetBooksAsync()
    {
        try
        {
            var searchPath = _configuration["Api:search"] ?? "/search";
            var response = await _httpClient.GetAsync($"{_apiUrl}{searchPath}?q=the+lord+of+the+rings");

            response.EnsureSuccessStatusCode(); // lanza excepción si no es 200

            var json = await response.Content.ReadAsStringAsync();

            // Asegúrate que BookDto coincide con el modelo JSON esperado
            var result = JsonSerializer.Deserialize<List<Object>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result ?? new List<Object>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching books: {ex.Message}");
            return new List<Object>();
        }
    }
}

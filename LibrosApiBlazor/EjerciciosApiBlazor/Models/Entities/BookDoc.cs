namespace EjerciciosApiBlazor.Models.Entities;

public class BookDoc
{
    public string Title { get; set; } = string.Empty;
    public List<string>? Author_name { get; set; }
    public int? First_publish_year { get; set; }
}

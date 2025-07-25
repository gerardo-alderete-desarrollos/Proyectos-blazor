using System.ComponentModel.DataAnnotations;

namespace CrudBlazor.Modelos;

public class Libro
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Titulo { get; set; } = string.Empty;
    [Required]
    public string Descripcion { get; set; } = string.Empty;
    [Required]
    public string Autor { get; set; } = string.Empty;
    [Required]
    public int Paginas { get; set; }
    [Required]
    public int Precio { get; set; }
    [Required]
    public DateTime FechaCreacion { get; set; } 
}

using CrudBlazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CrudBlazor.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {

    }

    //Poner aqui los modelos
    public DbSet<Libro> Libros { get; set; }
}

using CrudBlazor.Data;
using CrudBlazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CrudBlazor.Repositorio;

public class Repositorio : IRepositorio
{
    private readonly ApplicationDbContext _contexto;

    public Repositorio(ApplicationDbContext contexto)
    {
        _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
    }
    public async Task<Libro> ActualizarLibro(int libroId, Libro actualizarLibro)
    {
        var libroDesdeDB = await _contexto.Libros.FindAsync(libroId);
        libroDesdeDB!.Titulo = actualizarLibro.Titulo;
        libroDesdeDB.Descripcion = actualizarLibro.Descripcion;
        libroDesdeDB.Autor = actualizarLibro.Autor;
        libroDesdeDB.Paginas = actualizarLibro.Paginas;
        libroDesdeDB.Precio = actualizarLibro.Precio;
        libroDesdeDB.FechaCreacion = DateTime.Now;

        await _contexto.SaveChangesAsync(); 
        return libroDesdeDB;
    }

    public async Task<Libro> CrearLibro(Libro libro)
    {
        if (libro == null)
        {
            throw new ArgumentNullException(nameof(libro));
        }

        libro.FechaCreacion = DateTime.Now;
        await _contexto.Libros.AddAsync(libro);
        await _contexto.SaveChangesAsync();
        return libro;
    }

    public async Task EliminarLibro(int libroId)
    {
        var libroDesdeDB = await _contexto.Libros.FindAsync(libroId);
        if (libroDesdeDB == null)
        {
            throw new ArgumentNullException(nameof(libroDesdeDB));
        }

        _contexto.Libros.Remove(libroDesdeDB);
        await _contexto.SaveChangesAsync();
    }

    public async Task<Libro> GetLibroId(int libroId)
    {
        var libroDesdeDB = await _contexto.Libros.FindAsync(libroId);
        if (libroDesdeDB == null)
        {
            throw new ArgumentNullException(nameof(libroDesdeDB));
        }

        return libroDesdeDB;
    }

    public async Task<List<Libro>> GetLibros()
    {
        return await _contexto.Libros.ToListAsync();
    }
}

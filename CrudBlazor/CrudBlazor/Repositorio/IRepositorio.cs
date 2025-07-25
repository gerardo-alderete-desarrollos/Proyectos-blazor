using CrudBlazor.Modelos;

namespace CrudBlazor.Repositorio;

public interface IRepositorio
{
    public Task<List<Libro>> GetLibros();
    public Task<Libro> GetLibroId(int libroId);

    public Task<Libro> CrearLibro(Libro libro);
    public Task<Libro> ActualizarLibro(int libroId,Libro actualizarLibro);
    public Task EliminarLibro(int libroId);
}

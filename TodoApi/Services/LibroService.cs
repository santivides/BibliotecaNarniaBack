using TodoApi.Interfaces;
using TodoApi.Models;

public class LibroService : ILibroService
{
    private readonly ILibroRepository _libroRepository;

    public LibroService(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public async Task<IEnumerable<Libro>> ObtenerTodosLibros()
    {
        return await _libroRepository.ObtenerTodosLibros();
    }

    public async Task<Libro?> ObtenerPorTitulo(string titulo)
    {
        return await _libroRepository.ObtenerPorTitulo(titulo);
    }

    public async Task Agregar(Libro libro)
    {
        await _libroRepository.Agregar(libro);
    }

    public async Task Eliminar(int id)
    {
        await _libroRepository.Eliminar(id);
    }

    public async Task AlterarEstado(int id, bool estado)
    {
        await _libroRepository.AlterarEstado(id, estado);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Interfaces
{
    public interface ILibroRepository
    {
        Task Agregar(Libro libro);
        Task Eliminar(int libroId);
        Task AlterarEstado(int libroId, bool estado);
        Task<IEnumerable<Libro>> ObtenerTodosLibros();
        Task<Libro?> ObtenerPorTitulo(string titulo);
    }
}

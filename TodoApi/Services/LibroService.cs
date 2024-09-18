using System.Threading.Tasks;

namespace TodoApi.Services
{
    public class LibroService : ILibroService
    {
        public Task<string> AgregarLibro(string nombreLibro, string autor, string isbn, string fechaPublicacion, string descripcion, bool estado)
        {
            // Lógica para agregar libro (por ejemplo, interactuar con la base de datos)
            return Task.FromResult("Libro agregado exitosamente");
        }

        public Task<string> EliminarLibro(int id)
        {
            // Lógica para eliminar libro (por ejemplo, interactuar con la base de datos)
            return Task.FromResult("Libro eliminado exitosamente");
        }
    }
}

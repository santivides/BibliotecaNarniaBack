using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWCF;
using TodoApi.Models;

namespace TodoApi.Interfaces
{
    [ServiceContract]
    public interface ILibroService
    {
        [OperationContract]
        Task Agregar(Libro libro);
        
        [OperationContract]
        Task Eliminar(int id);

        [OperationContract]
        Task AlterarEstado(int id, bool estado);

        [OperationContract]
        Task<IEnumerable<Libro>> ObtenerTodosLibros();

        [OperationContract]
        Task<Libro?> ObtenerPorTitulo(string titulo);
    }
}

using TodoApi.Models;

namespace TodoApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObtenerUsuarioPorNumeroDocumentoAsync(string numeroDocumento);
        Task<Usuario?> ObtenerUsuarioPorCorreoAsync(string correo);
        Task<IEnumerable<Usuario>> ObtenerTodos();
        Task Agregar(Usuario usuario);
    }
}

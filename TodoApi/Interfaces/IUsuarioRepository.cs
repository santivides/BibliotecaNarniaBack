using TodoApi.Models;

namespace TodoApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObtenerUsuarioPorNumeroDocumento(string numeroDocumento);
        Task<Usuario?> ObtenerUsuarioPorCorreo(string correo);
        Task<IEnumerable<Usuario>> ObtenerTodos();
        Task Agregar(Usuario usuario);
    }
}

using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Interfaces
{
        public interface IUsuarioService
    {
        Task<Usuario> ObtenerUsuarioPorNumeroDocumento(string numeroDocumento);
        Task<Usuario> ObtenerUsuarioPorCorreo(string correo);
        Task<IEnumerable<Usuario>> ObtenerTodosUsuarios();
        Task RegistrarUsuario(Usuario usuario);
    }
}
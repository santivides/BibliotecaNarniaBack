using CoreWCF;
using TodoApi.Models;

namespace TodoApi.Interfaces
{
    [ServiceContract] // Esto es necesario para CoreWCF
    public interface IUsuarioService
    {
        [OperationContract]
        Task<Usuario?> ObtenerUsuarioPorNumeroDocumento(string numeroDocumento);

        [OperationContract]
        Task<Usuario?> ObtenerUsuarioPorCorreo(string correo);

        [OperationContract]
        Task<IEnumerable<Usuario>> ObtenerTodosUsuarios();

        [OperationContract]
        Task RegistrarUsuario(Usuario usuario);
    }
}

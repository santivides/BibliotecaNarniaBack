using TodoApi.Interfaces;
using TodoApi.Models;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario?> ObtenerUsuarioPorNumeroDocumento(string numeroDocumento)
    {
        return await _usuarioRepository.ObtenerUsuarioPorNumeroDocumentoAsync(numeroDocumento);
    }

    public async Task<Usuario?> ObtenerUsuarioPorCorreo(string correo)
    {
        return await _usuarioRepository.ObtenerUsuarioPorCorreoAsync(correo);
    }

    public async Task<IEnumerable<Usuario>> ObtenerTodosUsuarios()
    {
        return await _usuarioRepository.ObtenerTodos();
    }

    public async Task RegistrarUsuario(Usuario usuario)
    {
        await _usuarioRepository.Agregar(usuario);
    }

    Task<Usuario?> IUsuarioService.ObtenerUsuarioPorCorreo(string correo)
    {
        throw new NotImplementedException();
    }
}


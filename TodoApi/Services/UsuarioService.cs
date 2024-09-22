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
        return await _usuarioRepository.ObtenerUsuarioPorNumeroDocumento(numeroDocumento);
    }

    public async Task<Usuario?> ObtenerUsuarioPorCorreo(string correo)
    {
        return await _usuarioRepository.ObtenerUsuarioPorCorreo(correo);
    }

    public async Task<IEnumerable<Usuario>> ObtenerTodosUsuarios()
    {
        return await _usuarioRepository.ObtenerTodos();
    }

    public async Task RegistrarUsuario(Usuario usuario)
    {
        await _usuarioRepository.Agregar(usuario);
    }
}


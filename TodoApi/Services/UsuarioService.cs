using Microsoft.EntityFrameworkCore;
using TodoApi.Interfaces;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services
{

    public class UsuarioService : IUsuarioService {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> ObtenerUsuarioPorNumeroDocumento(string numeroDocumento) {
            return await _usuarioRepository.ObtenerPorNumeroDocumento(numeroDocumento);
        }

        public async Task<Usuario> ObtenerUsuarioPorCorreo(string correo) {
            return await _usuarioRepository.ObtenerPorCorreo(correo);  // Lógica para obtener por correo
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosUsuarios() {
            return await _usuarioRepository.ObtenerTodos();
        }

        public async Task RegistrarUsuario(Usuario usuario) {
            await _usuarioRepository.Agregar(usuario);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class UsuarioController : IUsuarioService {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) {
            _usuarioService = usuarioService;
        }

        public async Task<Usuario> ObtenerUsuarioPorNumeroDocumento(string numeroDocumento) {
            return await _usuarioService.ObtenerUsuarioPorNumeroDocumento(numeroDocumento);
        }

        public async Task<Usuario> ObtenerUsuarioPorCorreo(string correo) {
            return await _usuarioService.ObtenerUsuarioPorCorreo(correo);  // Lógica para obtener por correo
        }

        public async Task<string> RegistrarUsuario(Usuario usuario) {
            await _usuarioService.RegistrarUsuario(usuario);
            return "Usuario registrado exitosamente";
        }

        public Task<IEnumerable<Usuario>> ObtenerTodosUsuarios()
        {
            throw new NotImplementedException();
        }

        Task IUsuarioService.RegistrarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }

}
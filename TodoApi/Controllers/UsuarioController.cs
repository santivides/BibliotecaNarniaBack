using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuario/documento/{numeroDocumento}
        [HttpGet("documento/{numeroDocumento}")]
        public async Task<IActionResult> ObtenerUsuarioPorNumeroDocumento(string numeroDocumento)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorNumeroDocumento(numeroDocumento);
            if (usuario == null)
            {
                return NotFound($"Usuario con número de documento {numeroDocumento} no encontrado.");
            }
            return Ok(usuario);
        }

        [HttpGet("correo/{correo}")]
        public async Task<IActionResult> ObtenerUsuarioPorCorreo(string correo)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorCorreo(correo);
            if (usuario == null)
            {
                return NotFound($"Usuario con correo {correo} no encontrado.");
            }
            return Ok(usuario);
        }


        // POST: api/Usuario
        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usuarioService.RegistrarUsuario(usuario);
            return Ok("Usuario registrado exitosamente");
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<IActionResult> ObtenerTodosUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerTodosUsuarios();
            return Ok(usuarios);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbContext _context;

        public UsuarioService(DbContext context)
        {
            _context = context;
        }

        public async Task<string> AgregarUsuario(string nombre, string apellidos, string correo, string tipoDocumento, string numeroDocumento, string contrasena, bool esAdministrador)
        {
            // Verificar si el correo ya está registrado
            // var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.U_Correo == correo);
            // if (usuarioExistente != null)
            // {
            //     return "Error: El correo ya está registrado.";
            // }

            // Crear una nueva instancia del usuario
            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Correo = correo,
                TipoDocumento = tipoDocumento,
                NumeroDocumento = numeroDocumento,
                Contrasena = contrasena, // Idealmente, deberías encriptar la contraseña antes de guardarla
                Empleado = esAdministrador
            };

            // Agregar el nuevo usuario al contexto
            // await _context.Usuarios.AddAsync(nuevoUsuario);
            
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            return "Usuario agregado exitosamente";
        }
    }
}
using Microsoft.EntityFrameworkCore;
using TodoApi.Interfaces;

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
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.U_Correo == correo);
            if (usuarioExistente != null)
            {
                return "Error: El correo ya está registrado.";
            }

            // Crear una nueva instancia del usuario
            var nuevoUsuario = new Usuario
            {
                U_Nombre = nombre,
                U_Apellidos = apellidos,
                U_Correo = correo,
                U_TipoDocumento = tipoDocumento,
                U_Documento = numeroDocumento,
                U_Contraseña = contrasena, // Idealmente, deberías encriptar la contraseña antes de guardarla
                U_Empleado = esAdministrador
            };

            // Agregar el nuevo usuario al contexto
            await _context.Usuarios.AddAsync(nuevoUsuario);
            
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            return "Usuario agregado exitosamente";
        }
    }
}
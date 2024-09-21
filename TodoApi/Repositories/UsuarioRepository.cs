using Microsoft.EntityFrameworkCore;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TodoContext _context;

        public UsuarioRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerUsuarioPorCorreoAsync(string correo)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
        }

        public async Task<Usuario?> ObtenerUsuarioPorNumeroDocumentoAsync(string numeroDocumento)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.NumeroDocumento == numeroDocumento);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task Agregar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObtenerPorNumeroDocumento(string numeroDocumento);
        Task<Usuario> ObtenerPorCorreo(string correo);
        Task<IEnumerable<Usuario>> ObtenerTodos();
        Task Agregar(Usuario usuario);
        
        Task<Usuario?> ObtenerUsuarioPorCorreoAsync(string correo);
        Task<Usuario?> ObtenerUsuarioPorDocumentoAsync(string numeroDocumento);
    }
}
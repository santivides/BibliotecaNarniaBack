using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Services
{
    public interface ILibroService
    {
        Task<string> AgregarLibro(string nombreLibro, string autor, string isbn, string fechaPublicacion, string descripcion, bool estado);

        Task<string> EliminarLibro(int id);
    }
}
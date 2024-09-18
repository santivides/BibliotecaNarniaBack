using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Renta
    {
        public int Id { get; set; } // Identificador único de la renta
        public int UsuarioId { get; set; } // ID del usuario que ha rentado el libro
        public int LibroId { get; set; } // ID del libro que ha sido rentado
        public DateTime FechaRenta { get; set; } // Fecha en la que se realizó la renta
        public DateTime? FechaDevolucion { get; set; } // Fecha de devolución del libro (puede ser nula si aún no ha sido devuelto)

        // Relación entre usuario y libro (si usas Entity Framework o alguna otra ORM)
        public Usuario Usuario { get; set; }
    public Libro Libro { get; set; }
    }
}
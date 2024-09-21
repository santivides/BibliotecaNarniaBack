namespace TodoApi.Models
{
    public class Libro
    {
        public int Id { get; set; } // Identificador único del libro
        public string NombreLibro { get; set; }= string.Empty; // Título del libro
        public string Autor { get; set; } = string.Empty;// Autor del libro
        public string ISBN { get; set; } = string.Empty;// Código ISBN del libro
        public DateTime FechaPublicacion { get; set; } // Fecha de publicación del libro
        public string Descripcion { get; set; }= string.Empty; // Breve descripción del libro
        public bool Estado { get; set; } // Estado del libro: true = Prestado, false = Disponible
    }
}
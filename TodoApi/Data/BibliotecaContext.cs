using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        // Definir las tablas en la base de datos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Renta> Rentas { get; set; }
    }
}

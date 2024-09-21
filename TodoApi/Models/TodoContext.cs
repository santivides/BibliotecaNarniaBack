using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    // DbSet para la tabla Usuarios
    public DbSet<Usuario> Usuarios { get; set; }

    // DbSet para otras tablas, como Libros y Rentas
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Renta> Rentas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar restricciones adicionales, relaciones, etc.
    }
}

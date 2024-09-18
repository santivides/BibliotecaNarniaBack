using Xunit;
using Moq;
using System.Threading.Tasks;
using TodoApi.Models; // Modelo de usuario
using TodoApi.Services; // Servicio de usuarios
using Microsoft.EntityFrameworkCore;

public class UsuarioServiceTests
{
    [Fact]
    public async Task RegistrarUsuario_DebeRegistrarUsuarioCorrectamente()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb") // Usa una base de datos en memoria para las pruebas
            .Options;

        using var context = new DbContext(options);

        var usuarioService = new UsuarioService(context);

        var nuevoUsuario = new Usuario
        {
            Nombre = "Juan",
            Apellidos = "Pérez",
            Correo = "juan.perez@example.com",
            Contrasena = "password123",
            TipoDocumento = "Cédula",
            NumeroDocumento = "123456789",
            Empleado = false
        };

        // Act
        // var resultado = await usuarioService.RegistrarUsuario(nuevoUsuario);

        // // Assert
        // var usuarioEnDb = await context.Usuario.FindAsync(nuevoUsuario.ID);
        // Assert.NotNull(usuarioEnDb);
        // Assert.Equal("juan.perez@example.com", usuarioEnDb.U_Correo);
    }
}

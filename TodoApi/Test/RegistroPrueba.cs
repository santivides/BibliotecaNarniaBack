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
            U_Nombre = "Juan",
            U_Apellidos = "Pérez",
            U_Correo = "juan.perez@example.com",
            U_Contraseña = "password123",
            U_TipoDocumento = "Cédula",
            U_Documento = "123456789",
            U_Empleado = false
        };

        // Act
        var resultado = await usuarioService.RegistrarUsuario(nuevoUsuario);

        // Assert
        var usuarioEnDb = await context.Usuarios.FindAsync(nuevoUsuario.U_ID);
        Assert.NotNull(usuarioEnDb);
        Assert.Equal("juan.perez@example.com", usuarioEnDb.U_Correo);
    }
}

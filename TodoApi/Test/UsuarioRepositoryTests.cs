using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Repositories;
using Xunit;

public class UsuarioRepositoryTests
{
    private readonly UsuarioRepository _usuarioRepository;
    private readonly string _connectionString = "Driver={ODBC Driver 18 for SQL Server};Server=localhost;Database=BibliotecaNarnia;Trusted_Connection=True;";

    public UsuarioRepositoryTests()
    {
        _usuarioRepository = new UsuarioRepository(_connectionString);
    }

    [Fact]
    public async Task AgregarUsuario_CreaNuevoUsuario()
    {
        // Arrange
        var nuevoUsuario = new Usuario
        {
            Nombre = "Carlos",
            Apellidos = "Martínez",
            Correo = "carlos.martinez@example.com",
            Contrasena = "password123",
            TipoDocumento = "DNI",
            NumeroDocumento = "12345678",
            Empleado = false
        };

        // Act
        await _usuarioRepository.Agregar(nuevoUsuario);

        // Assert
        var usuarioCreado = await _usuarioRepository.ObtenerUsuarioPorCorreo(nuevoUsuario.Correo);
        Assert.NotNull(usuarioCreado);
        Assert.Equal(nuevoUsuario.Nombre, usuarioCreado.Nombre);
        Assert.Equal(nuevoUsuario.Apellidos, usuarioCreado.Apellidos);
        Assert.Equal(nuevoUsuario.Correo, usuarioCreado.Correo);
    }
}

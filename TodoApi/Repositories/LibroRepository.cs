using System.Collections.Generic;
using System.Data.Odbc;
using System.Threading.Tasks;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly string _connectionString;

        public LibroRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Agregar(Libro libro)
        {
            using var connection = new OdbcConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new OdbcCommand("INSERT INTO Libros (Titulo, Autor, ISBN, Estado) VALUES (?, ?, ?, ?)", connection);
            command.Parameters.AddWithValue("Titulo", libro.NombreLibro);
            command.Parameters.AddWithValue("Autor", libro.Autor);
            command.Parameters.AddWithValue("ISBN", libro.ISBN);
            command.Parameters.AddWithValue("Estado", libro.Estado);

            await command.ExecuteNonQueryAsync();
        }

        public async Task Eliminar(int libroId)
        {
            using var connection = new OdbcConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new OdbcCommand("DELETE FROM Libros WHERE L_ID = ?", connection);
            command.Parameters.AddWithValue("L_ID", libroId);

            await command.ExecuteNonQueryAsync();
        }

        public async Task AlterarEstado(int libroId, bool estado)
        {
            using var connection = new OdbcConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new OdbcCommand("UPDATE Libros SET Estado = ? WHERE L_ID = ?", connection);
            command.Parameters.AddWithValue("Estado", estado);
            command.Parameters.AddWithValue("L_ID", libroId);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<Libro>> ObtenerTodosLibros()
        {
            var libros = new List<Libro>();

            using var connection = new OdbcConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new OdbcCommand("SELECT * FROM Libros", connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                libros.Add(new Libro
                {
                    NombreLibro = reader.GetString(1),
                    Autor = reader.GetString(2),
                    ISBN = reader.GetString(3),
                    Estado = reader.GetBoolean(4)
                });
            }

            return libros;
        }

        public async Task<Libro?> ObtenerPorTitulo(string titulo)
        {
            using var connection = new OdbcConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new OdbcCommand("SELECT * FROM Libros WHERE Titulo = ?", connection);
            command.Parameters.AddWithValue("Titulo", titulo);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Libro
                {
                    NombreLibro = reader.GetString(1),
                    Autor = reader.GetString(2),
                    ISBN = reader.GetString(3),
                    Estado = reader.GetBoolean(4)
                };
            }

            return null;
        }
    }
}

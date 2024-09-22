using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Threading.Tasks;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Usuario?> ObtenerUsuarioPorCorreo(string correo)
        {
            using (var connection = new OdbcConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new OdbcCommand("SELECT * FROM Usuarios WHERE U_Correo = ?", connection))
                {
                    command.Parameters.Add(new OdbcParameter("Correo", correo));
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapToUsuario(reader);
                        }
                    }
                }
            }
            return null;
        }

        public async Task<Usuario?> ObtenerUsuarioPorNumeroDocumento(string numeroDocumento)
        {
            using (var connection = new OdbcConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new OdbcCommand("SELECT * FROM Usuarios WHERE U_Documento = ?", connection))
                {
                    command.Parameters.Add(new OdbcParameter("Documento", numeroDocumento));
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapToUsuario(reader);
                        }
                    }
                }
            }
            return null;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodos()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new OdbcConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new OdbcCommand("SELECT * FROM Usuarios", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            usuarios.Add(MapToUsuario(reader));
                        }
                    }
                }
            }

            return usuarios;
        }

        public async Task Agregar(Usuario usuario)
        {
            using (var connection = new OdbcConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new OdbcCommand("INSERT INTO Usuarios (U_Nombre, U_Apellidos, U_Correo, U_Contraseña, U_TipoDocumento, U_Documento, U_Empleado) VALUES (?, ?, ?, ?, ?, ?, ?)", connection))
                {
                    command.Parameters.Add(new OdbcParameter("Nombre", usuario.Nombre));
                    command.Parameters.Add(new OdbcParameter("Apellidos", usuario.Apellidos));
                    command.Parameters.Add(new OdbcParameter("Correo", usuario.Correo));
                    command.Parameters.Add(new OdbcParameter("Contraseña", usuario.Contrasena));
                    command.Parameters.Add(new OdbcParameter("TipoDocumento", usuario.TipoDocumento));
                    command.Parameters.Add(new OdbcParameter("Documento", usuario.NumeroDocumento));
                    command.Parameters.Add(new OdbcParameter("Empleado", usuario.Empleado));

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private Usuario MapToUsuario(IDataReader reader)
        {
            return new Usuario
            {
                Id = reader.GetInt32(reader.GetOrdinal("U_ID")),
                Nombre = reader.GetString(reader.GetOrdinal("U_Nombre")),
                Apellidos = reader.GetString(reader.GetOrdinal("U_Apellidos")),
                Correo = reader.GetString(reader.GetOrdinal("U_Correo")),
                Contrasena = reader.GetString(reader.GetOrdinal("U_Contraseña")),
                TipoDocumento = reader.GetString(reader.GetOrdinal("U_TipoDocumento")),
                NumeroDocumento = reader.GetString(reader.GetOrdinal("U_Documento")),
                Empleado = reader.GetBoolean(reader.GetOrdinal("U_Empleado")),
            };
        }
    }
}

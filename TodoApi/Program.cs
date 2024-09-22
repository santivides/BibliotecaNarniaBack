using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión
var connectionString = "Driver={ODBC Driver 18 for SQL Server};Server=localhost;Database=BibliotecaNarnia;Trusted_Connection=True;";

// Registrar servicios y repositorios
builder.Services.AddScoped<IUsuarioRepository>(provider => new UsuarioRepository(connectionString));
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<ILibroRepository>(provider => new LibroRepository(connectionString));
builder.Services.AddScoped<ILibroService, LibroService>();


// Configurar WCF en el proyecto
builder.Services.AddServiceModelServices();

// Agregar controladores
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuración del servicio WCF
app.UseServiceModel(builder =>
{
    builder.AddService<UsuarioService>();
    builder.AddServiceEndpoint<UsuarioService, IUsuarioService>(new BasicHttpBinding(), "/UsuarioService");

    builder.AddService<ILibroService>();
    builder.AddServiceEndpoint<ILibroService, ILibroService>(new BasicHttpBinding(), "/LibroService");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

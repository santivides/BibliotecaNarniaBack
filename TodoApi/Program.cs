using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TodoApi.Services;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configurar WCF en el proyecto
builder.Services.AddServiceModelServices();

// Configuración de la base de datos
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios y repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Configurar CoreWCF para servicios SOAP
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
app.UseServiceModel(builder => {
    builder.AddService<UsuarioService>();
    builder.AddServiceEndpoint<UsuarioService, IUsuarioService>(
        new BasicHttpBinding(), "/UsuarioService");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

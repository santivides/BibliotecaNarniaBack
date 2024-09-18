using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Hosting;
using TodoApi.Services;
using TuNombreEspacio.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configurar WCF en el proyecto
builder.Services.AddServiceModelServices();

builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuración del servicio WCF
app.UseServiceModel(builder =>
{
    builder.AddService<LibroService>();
    builder.AddServiceEndpoint<LibroService, ILibroService>(new BasicHttpBinding(), "/LibrosService");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



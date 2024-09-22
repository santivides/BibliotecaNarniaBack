using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        // POST: api/Libro
        [HttpPost]
        public async Task<IActionResult> AgregarLibro([FromBody] Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _libroService.Agregar(libro);
            return Ok("Libro agregado exitosamente");
        }

        // DELETE: api/Libro/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarLibro(int id)
        {
            await _libroService.Eliminar(id);
            return Ok("Libro eliminado exitosamente");
        }

        // PUT: api/Libro/{id}/estado
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> AlterarEstado(int id, [FromBody] bool estado)
        {
            await _libroService.AlterarEstado(id, estado);
            return Ok("Estado del libro actualizado exitosamente");
        }

        // GET: api/Libro
        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLibros()
        {
            var libros = await _libroService.ObtenerTodosLibros();
            return Ok(libros);
        }

        // GET: api/Libro/titulo/{titulo}
        [HttpGet("titulo/{titulo}")]
        public async Task<IActionResult> ObtenerLibroPorTitulo(string titulo)
        {
            var libro = await _libroService.ObtenerPorTitulo(titulo);
            if (libro == null)
            {
                return NotFound($"Libro con título '{titulo}' no encontrado.");
            }
            return Ok(libro);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Dominio.Prestamos;
using PruebaIngresoBibliotecario.Negocio.Prestamos;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Controllers.Prestamos
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoLibroManager _prestamoLibroManager;

        public PrestamoController(IPrestamoLibroManager prestamoLibroManager)
        {
            _prestamoLibroManager = prestamoLibroManager;
        }


        [HttpPost]
        public async Task<ActionResult> PostPrestamo([FromBody] PrestamoLibro prestamoLibro)
        {
            try
            {
                return Ok(await _prestamoLibroManager.GuardarPrestamoLibro(prestamoLibro));
            }
            catch (Exception)
            {

                return BadRequest("El tipo de usuario no es valido.");
            }
        }

        [HttpGet("{idPrestamo}")]
        public async Task<ActionResult> SeleccionarPrestamoLibroPorId(Guid idPrestamo)
        {
            try
            {
                return Ok(await _prestamoLibroManager.SeleccionarPrestamoLibroPorId(idPrestamo));
            }
            catch (Exception)
            {
                return NotFound(new { mensaje = "El prestamo con id " + idPrestamo + " no exite." });
            }
        }

    }
}

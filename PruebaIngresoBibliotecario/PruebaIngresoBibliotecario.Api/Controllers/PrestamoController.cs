using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Dominio;
using PruebaIngresoBibliotecario.Negocio.Prestamos;
using System.CodeDom;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Controllers
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
            catch (System.Exception)
            {

                return BadRequest("El tipo de usuario no es valido.");
            }
        }

    }
}

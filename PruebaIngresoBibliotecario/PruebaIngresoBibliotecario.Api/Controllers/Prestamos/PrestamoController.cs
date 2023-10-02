using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Api.Controllers.Prestamos;
using PruebaIngresoBibliotecario.Dominio.Prestamos;
using PruebaIngresoBibliotecario.Negocio.Prestamos;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoLibroManager _prestamoLibroManager;
        private readonly IMapper _mapper;

        public PrestamoController(IPrestamoLibroManager prestamoLibroManager, IMapper mapper)
        {
            _prestamoLibroManager = prestamoLibroManager;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> PostPrestamo([FromBody] PrestamoLibroDTO prestamoLibro)
        {
            var respuesta = new PrestamoLibroDTO();

            try
            {
                var modelo = _mapper.Map<PrestamoLibro>(prestamoLibro);
                var prestamoCreado = await _prestamoLibroManager.GuardarPrestamoLibro(modelo);
                respuesta = _mapper.Map<PrestamoLibroDTO>(prestamoCreado);





                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
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

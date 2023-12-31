﻿using AutoMapper;
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
        public async Task<ActionResult> PostPrestamo([FromBody] PrestamoLibro prestamoLibro)
        {
            try
            {
                var modelo = _mapper.Map<PrestamoLibro>(prestamoLibro);
                var prestamoCreado = await _prestamoLibroManager.GuardarPrestamoLibro(modelo);
                var respuesta = _mapper.Map<PrestamoLibroDTO>(prestamoCreado);

                return Ok(new { id = respuesta.Id, respuesta.FechaMaximaDevolucion });
            }
            catch (InvalidOperationException)
            {
                return StatusCode(400, new { mensaje = $"El usuario con identificacion {prestamoLibro.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo" });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { mensaje = ex.Message });
            }
        }

        [HttpGet("{idPrestamo}")]
        public async Task<ActionResult> SeleccionarPrestamoLibroPorId(Guid idPrestamo)
        {
            try
            {
                var resultado = await _prestamoLibroManager.SeleccionarPrestamoLibroPorId(idPrestamo).ConfigureAwait(false);

                if (resultado == null)
                    return NotFound((new { mensaje = "El prestamo con id " + idPrestamo + " no exite." }));

                return Ok(resultado);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}

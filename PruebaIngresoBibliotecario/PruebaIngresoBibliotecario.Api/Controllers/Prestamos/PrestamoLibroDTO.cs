using System;

namespace PruebaIngresoBibliotecario.Api.Controllers.Prestamos
{
    public class PrestamoLibroDTO
    {
        public Guid Id { get; set; }
        public Guid Isbn { get; set; }
        public string IdentificacionUsuario { get; set; } = default!;
        public string TipoUsuario { get; set; } = default!;
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}

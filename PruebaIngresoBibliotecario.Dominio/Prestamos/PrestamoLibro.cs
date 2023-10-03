using PruebaIngresoBibliotecario.Dominio.Usuarios;
using System;

namespace PruebaIngresoBibliotecario.Dominio.Prestamos
{
    public class PrestamoLibro
    {
        public Guid Id { get; set; }
        public Guid Isbn { get; set; }
        public string IdentificacionUsuario { get; set; } = default!;
        public TipoUsuario TipoUsuario { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }
    }
}

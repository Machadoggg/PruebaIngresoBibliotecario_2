using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaIngresoBibliotecario.Dominio
{
    public class PrestamoLibro
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Isbn { get; set; }
        public string IdentificacionUsuario { get; set; } = default;
        public int TipoUsuario { get; set; }
        public DateTime? FechaMaximaDevolucion { get; set; }
    }
}

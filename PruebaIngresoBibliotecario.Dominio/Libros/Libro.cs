using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaIngresoBibliotecario.Dominio
{
    public class Libro
    {
        [Key]
        public Guid Isbn { get; set; }
        public string NombreLibro { get; set; } = default;
    }
}

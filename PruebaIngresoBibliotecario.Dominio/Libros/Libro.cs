using System;

namespace PruebaIngresoBibliotecario.Dominio.Libros
{
    public class Libro
    {
        public Guid Isbn { get; set; }
        public string NombreLibro { get; set; } = default!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace PruebaIngresoBibliotecario.Dominio
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string IdentificacionUsuario { get; set; } = default;
        public int TipoUsuario { get; set; }
    }
}

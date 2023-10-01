namespace PruebaIngresoBibliotecario.Dominio.Usuarios
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string IdentificacionUsuario { get; set; } = default!;
        public int TipoUsuario { get; set; }
    }
}

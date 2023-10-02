using PruebaIngresoBibliotecario.Dominio.Prestamos;

namespace PruebaIngresoBibliotecario.Negocio.Prestamos
{
    public interface IPrestamoLibroRepositorio
    {
        Task<PrestamoLibro> GuardarPrestamoLibro(PrestamoLibro prestamoLibro);

        Task<PrestamoLibro?> SeleccionarPrestamoLibroPorId(Guid idPrestamo);
    }
}

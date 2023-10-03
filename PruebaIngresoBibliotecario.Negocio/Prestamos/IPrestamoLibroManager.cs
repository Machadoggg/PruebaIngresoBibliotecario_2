using PruebaIngresoBibliotecario.Dominio.Prestamos;

namespace PruebaIngresoBibliotecario.Negocio.Prestamos
{
    public interface IPrestamoLibroManager
    {
        Task<PrestamoLibro> GuardarPrestamoLibro(PrestamoLibro prestamoLibro);

        Task<PrestamoLibro?> SeleccionarPrestamoLibroPorId(Guid idPrestamo);
    }
}

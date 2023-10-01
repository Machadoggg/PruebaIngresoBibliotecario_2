using PruebaIngresoBibliotecario.Dominio.Prestamos;

namespace PruebaIngresoBibliotecario.Negocio.Prestamos
{
    public class PrestamoLibroManager : IPrestamoLibroManager
    {
        private readonly IPrestamoLibroRepositorio _prestamoLibroRepositorio;

        public PrestamoLibroManager(IPrestamoLibroRepositorio prestamoLibroRepositorio)
        {
            _prestamoLibroRepositorio = prestamoLibroRepositorio;
        }


        public async Task<PrestamoLibro> GuardarPrestamoLibro(PrestamoLibro prestamoLibro)
        {
            return await _prestamoLibroRepositorio.GuardarPrestamoLibro(prestamoLibro);
        }

        public async Task<PrestamoLibro> SeleccionarPrestamoLibroPorId(Guid idPrestamo)
        {
            return await _prestamoLibroRepositorio.SeleccionarPrestamoLibroPorId(idPrestamo);
        }
    }
}

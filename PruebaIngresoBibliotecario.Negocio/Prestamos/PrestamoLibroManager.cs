using PruebaIngresoBibliotecario.Dominio;
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

        public Task<PrestamoLibro> SeleccionarPrestamoLibroPorId(Guid idPrestamo)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Dominio;
using PruebaIngresoBibliotecario.Dominio.Prestamos;
using PruebaIngresoBibliotecario.Negocio.Prestamos;

namespace PruebaIngresoBibliotecario.Datos.Prestamos
{
    public class PrestamoLibroRepositorio : IPrestamoLibroRepositorio
    {

        private readonly BibliotecaContext _bibliotecaContext;

        public PrestamoLibroRepositorio(BibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }


        public async Task<PrestamoLibro> GuardarPrestamoLibro(PrestamoLibro prestamoLibro)
        {
            PrestamoLibro Resultado = default!;
            try
            {
                if (prestamoLibro.Id == Guid.Empty)
                {
                    var weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
                    var fechaDevolucion = DateTime.Now;
                    int diasPrestamo = 0;

                    diasPrestamo = await ValidarUsuario(prestamoLibro, diasPrestamo);

                    for (int i = 0; i < diasPrestamo;)
                    {
                        fechaDevolucion = fechaDevolucion.AddDays(1);
                        i = (!weekend.Contains(fechaDevolucion.DayOfWeek)) ? ++i : i;
                    }

                    prestamoLibro.FechaMaximaDevolucion = fechaDevolucion;
                    prestamoLibro.Id = Guid.NewGuid();
                    _bibliotecaContext.PrestamoLibros.Add(prestamoLibro);
                }
                else
                {
                    _bibliotecaContext.Attach(prestamoLibro).State = EntityState.Modified;
                }

                if (await _bibliotecaContext.SaveChangesAsync() > 0)
                {
                    Resultado = prestamoLibro;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }

        private async Task<int> ValidarUsuario(PrestamoLibro prestamoLibro, int diasPrestamo)
        {
            switch (prestamoLibro.TipoUsuario) 
            {
                case 1:
                    diasPrestamo = 10;
                    break;
                case 2:
                    diasPrestamo = 8;
                    break;
                case 3:
                    var tipoUsuario3 = await _bibliotecaContext.PrestamoLibros.FirstOrDefaultAsync(
                        x => x.IdentificacionUsuario == prestamoLibro.IdentificacionUsuario);
                    if (tipoUsuario3 != null)
                    {
                        break;
                    }

                    diasPrestamo = 7;
                    break;
                default:
                    break;
            }
            return diasPrestamo;
        }

        public Task<PrestamoLibro> SeleccionarPrestamoLibroPorId(Guid idPrestamo)
        {
            throw new NotImplementedException();
        }
    }
}

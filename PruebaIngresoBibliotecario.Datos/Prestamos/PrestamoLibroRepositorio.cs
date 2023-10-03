using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Dominio.Prestamos;
using PruebaIngresoBibliotecario.Dominio.Usuarios;
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
            

            if (!Guid.TryParse(prestamoLibro.Isbn.ToString(), out _))
            {
                return prestamoLibro;
            }
            var prestamo = new PrestamoLibro
            {
                Isbn = prestamoLibro.Isbn,
                IdentificacionUsuario = prestamoLibro.IdentificacionUsuario,
                TipoUsuario = prestamoLibro.TipoUsuario
            };
            var weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var fechaDevolucion = DateTime.Now;
            int diasPrestamo = 0;

            diasPrestamo = await ValidarUsuario(prestamoLibro, diasPrestamo);

            

            for (int i = 0; i < diasPrestamo;)
            {
                fechaDevolucion = fechaDevolucion.AddDays(1);
                i = (!weekend.Contains(fechaDevolucion.DayOfWeek)) ? ++i : i;
            }
            prestamo.FechaMaximaDevolucion = fechaDevolucion;
            prestamo.Id = Guid.NewGuid();
            _bibliotecaContext.PrestamoLibros.Add(prestamo);
            await _bibliotecaContext.SaveChangesAsync();
            
            return prestamo;
        }

        private async Task<int> ValidarUsuario(PrestamoLibro prestamoLibro, int diasPrestamo)
        {
            switch (prestamoLibro.TipoUsuario)
            {
                case TipoUsuario.AFILIADO:
                    diasPrestamo = 10;
                    break;
                case TipoUsuario.EMPLEADO:
                    diasPrestamo = 8;
                    break;
                case TipoUsuario.INVITADO:
                   var usuarioPrestamo = await _bibliotecaContext.PrestamoLibros.FirstOrDefaultAsync(
                        x => x.IdentificacionUsuario == prestamoLibro.IdentificacionUsuario);
                    if (usuarioPrestamo != null)
                    {
                        throw new InvalidOperationException();
                    }

                    diasPrestamo = 7;
                    break;
                default:
                    throw new Exception(); ;
            }
            return diasPrestamo;
        }

        public async Task<PrestamoLibro?> SeleccionarPrestamoLibroPorId(Guid idPrestamo)
        {
            
            try
            {
                var resultado = (await _bibliotecaContext.PrestamoLibros.FirstOrDefaultAsync(p => p.Id == idPrestamo))!;
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

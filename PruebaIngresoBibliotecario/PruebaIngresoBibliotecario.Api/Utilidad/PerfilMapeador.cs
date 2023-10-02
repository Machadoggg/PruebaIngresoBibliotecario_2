using AutoMapper;
using PruebaIngresoBibliotecario.Api.Controllers.Prestamos;
using PruebaIngresoBibliotecario.Dominio.Prestamos;

namespace PruebaIngresoBibliotecario.Api.Utilidad
{
    public class PerfilMapeador : Profile
    {
        public PerfilMapeador()
        {
            #region

            CreateMap<PrestamoLibro, PrestamoLibroDTO>()
                .ForMember(x => x.TipoUsuario, opt => opt.MapFrom(src => src.TipoUsuario.ToString()));

            //CreateMap<PrestamoLibroDTO, PrestamoLibro>();
            

            #endregion
        }
    }
}

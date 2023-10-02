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
            CreateMap<PrestamoLibroDTO, PrestamoLibro>();
            // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Isbn, opt => opt.MapFrom(src => src.Isbn))
            //.ForMember(dest => dest.FechaMaximaDevolucion, opt => opt.MapFrom(src => src.FechaMaximaDevolucion));

            CreateMap<PrestamoLibro, PrestamoLibroDTO>();
                // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Isbn, opt => opt.MapFrom(src => src.Isbn))
                //.ForMember(dest => dest.FechaMaximaDevolucion, opt => opt.MapFrom(src => src.FechaMaximaDevolucion));


            
            #endregion
        }
    }
}

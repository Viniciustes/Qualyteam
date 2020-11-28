using AutoMapper;
using Qualyteam.Application.ViewModels;
using Qualyteam.Domain.Models;

namespace Qualyteam.Domain.AutoMapper
{
    class ColetaProfile : Profile
    {
        public ColetaProfile()
        {
            //ViewModel to Model
            CreateMap<ColetaRequestViewModel, Coleta>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.DataColeta, opt => opt.MapFrom(src => src.DataColeta))
                .ForPath(dest => dest.IndicadorMensal.Id, opt => opt.MapFrom(src => src.IdIndicadorMensal));

            //Model to ViewModel
            CreateMap<Coleta, ColetaViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.DataColeta, opt => opt.MapFrom(src => src.DataColeta))
                .ForMember(dest => dest.IndicadorMensal, opt => opt.MapFrom(src => src.IndicadorMensal));
        }
    }
}

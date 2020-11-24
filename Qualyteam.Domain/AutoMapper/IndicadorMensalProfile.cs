using AutoMapper;
using Qualyteam.Application.ViewModels;
using Qualyteam.Domain.Models;

namespace Qualyteam.Domain.AutoMapper
{
    class IndicadorMensalProfile : Profile
    {
        public IndicadorMensalProfile()
        {
            //ViewModel to Model
            CreateMap<IndicadorMensalViewModel, IndicadorMensal>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                    .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio));

            //Model to ViewModel
            CreateMap<IndicadorMensal, IndicadorMensalViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                    .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio));
        }
    }
}

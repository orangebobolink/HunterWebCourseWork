using AutoMapper;
using BLL.DTOs.HuntingSeason;
using DAL.Entities.HuntingSeasonEntities;

namespace BLL.Mappings
{
    internal class HuntingOfSeasonDetailProfile : Profile
    {
        public HuntingOfSeasonDetailProfile()
        {
            CreateMap<HuntingSeason, HuntingSeasonDetailDTO>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.HuntingSeasonDetail.Description))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.HuntingSeasonDetail.TypeOfHunting.Name))
                .ForMember(dest => dest.MethodName, opt => opt.MapFrom(src => src.HuntingSeasonDetail.MethodOfHunting.Name))
                .ForMember(dest => dest.HuntingTime, opt => opt.MapFrom(src => src.HuntingSeasonDetail.HuntingTime))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.HuntingSeasonDetail.Gender.Name))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.HuntingSeasonDetail.Age))
                .ReverseMap();
        }
    }
}

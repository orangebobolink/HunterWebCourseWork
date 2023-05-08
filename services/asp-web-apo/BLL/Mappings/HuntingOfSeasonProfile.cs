using AutoMapper;
using BLL.DTOs;
using DAL.Entities.HuntingSeasonEntities;

namespace BLL.Mappings
{
    internal class HuntingOfSeasonProfile : Profile
    {
        public HuntingOfSeasonProfile()
        {
            CreateMap<HuntingSeason, HuntingSeasonDTO>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.HuntingSeasonDetail!.Description))
                .ReverseMap();
        }
    }
}

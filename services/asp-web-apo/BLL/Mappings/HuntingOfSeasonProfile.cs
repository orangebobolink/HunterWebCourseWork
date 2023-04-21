using AutoMapper;
using BLL.DTOs.HuntingSeason;
using DAL.Entities.HuntingSeasonEntities;

namespace BLL.Mappings
{
    internal class HuntingOfSeasonProfile : Profile
    {
        public HuntingOfSeasonProfile()
        {
            CreateMap<HuntingSeason, HuntingSeasonDTO>().ReverseMap();
        }
    }
}

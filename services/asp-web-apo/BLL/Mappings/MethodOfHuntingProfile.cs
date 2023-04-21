using AutoMapper;
using BLL.DTOs.HuntingSeason;
using DAL.Entities.HuntingSeasonEntities;

namespace BLL.Mappings
{
    internal class MethodOfHuntingProfile : Profile
    {
        public MethodOfHuntingProfile()
        {
            CreateMap<MethodOfHunting, MethodOfHuntingDTO>().ReverseMap();
        }
    }
}

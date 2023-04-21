using AutoMapper;
using BLL.DTOs.HuntingSeason;
using DAL.Entities.HuntingSeasonEntities;

namespace BLL.Mappings
{
    internal class TypeOfHuntingProfile : Profile
    {
        public TypeOfHuntingProfile()
        {
            CreateMap<TypeOfHunting, TypeOfHuntingDTO>().ReverseMap();
        }
    }
}

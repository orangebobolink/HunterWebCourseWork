using AutoMapper;
using BLL.DTOs.HuntingSeason;
using DAL.Entities.HuntingSeasonEntities;

namespace BLL.Mappings
{
    internal class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDTO>().ReverseMap();
        }
    }
}

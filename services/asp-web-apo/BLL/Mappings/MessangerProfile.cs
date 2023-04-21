using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class MessangerProfile : Profile
    {
        public MessangerProfile()
        {
            CreateMap<Messanger, MessangerDTO>().ReverseMap();
        }
    }
}

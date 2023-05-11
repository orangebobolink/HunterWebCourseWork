using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusDTO>().ReverseMap();
        }
    }
}

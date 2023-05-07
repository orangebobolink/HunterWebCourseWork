using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>()
                 .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status!.Name))
                .ReverseMap();
        }
    }
}

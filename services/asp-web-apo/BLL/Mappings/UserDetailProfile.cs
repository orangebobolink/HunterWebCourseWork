using AutoMapper;
using BLL.DTOs.UserDTOs;
using BLL.Resolvers;
using DAL.Entities.UserEntities;

namespace BLL.Mappings
{
    internal class UserDetailProfile : Profile
    {
        public UserDetailProfile()
        {
            CreateMap<User, UserDetailDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.UserDetail.FirstName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.UserDetail.Phone))
                .ForMember(dest => dest.Messanger, opt => opt.MapFrom(src => src.UserDetail.Messanger.Name))
                .ReverseMap();
        }
    }
}

using AutoMapper;
using BLL.DTOs.UserDTOs;
using BLL.Resolvers;
using DAL.Entities.UserEntities;

namespace BLL.Mappings
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom<UserRoleResolver>())
                .ReverseMap();

            CreateMap<User, RequestUserDTO>().ReverseMap();
        }
    }
}

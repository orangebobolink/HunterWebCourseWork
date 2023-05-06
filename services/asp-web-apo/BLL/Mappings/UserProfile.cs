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

            CreateMap<User, ResponseUserDto>()
                .ReverseMap();

            CreateMap<UserDTO, ResponseUserDto>()
                .ReverseMap();

            CreateMap<User, UserDetailDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.UserDetail.FirstName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.UserDetail.Phone))
                .ForMember(dest => dest.Messanger, opt => opt.MapFrom(src => src.UserDetail.Messanger.Name))
                .ReverseMap();

            CreateMap<User, RegisterUserDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.UserDetail.FirstName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.UserDetail.Phone))
                .ForMember(dest => dest.Messanger, opt => opt.MapFrom(src => src.UserDetail.Messanger.Name))
                .ReverseMap();
        }
    }
}

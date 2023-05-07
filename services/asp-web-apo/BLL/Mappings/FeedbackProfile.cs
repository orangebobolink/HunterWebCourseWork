using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<Feedback, FeedbackDTO>()
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User!.Email))
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User!.UserDetail!.FirstName))
                .ReverseMap();
        }
    }
}

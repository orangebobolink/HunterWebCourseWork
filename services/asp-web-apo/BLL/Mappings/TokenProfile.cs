using AutoMapper;
using BLL.DTOs.TokenDTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<Token, TokenDTO>().ReverseMap();
        }
    }
}

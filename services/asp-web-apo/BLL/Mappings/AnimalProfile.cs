using AutoMapper;
using BLL.DTOs.Animal;
using DAL.Entities.AnimalEntities;

namespace BLL.Mappings
{
    internal class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalDTO>().ReverseMap();

            CreateMap<Animal, AnimalDetailDTO>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.AnimalDetail!.Description))
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.AnimalDetail!.TableId))
                .ReverseMap();
        }
    }
}

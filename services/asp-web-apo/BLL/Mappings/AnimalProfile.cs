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
        }
    }
}

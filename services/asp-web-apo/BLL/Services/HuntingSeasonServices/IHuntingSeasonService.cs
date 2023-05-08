using BLL.DTOs;
using BLL.Interfaces;

namespace BLL.Services.HuntingSeasonServices
{
    public interface IHuntingSeasonService : IBaseService<HuntingSeasonDTO>
    {
        public Task<IEnumerable<HuntingSeasonDTO>> GetAllByAnimalIdAsync(int animalId);
    }
}

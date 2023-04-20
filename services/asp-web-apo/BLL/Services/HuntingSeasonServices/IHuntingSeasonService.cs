using BLL.DTOs.HuntingSeason;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services.HuntingSeasonServices
{
    public interface IHuntingSeasonService : IRepositoryService<HuntingSeasonDetailDTO>
    {
        public Task<IEnumerable<HuntingSeasonDTO>> GetAllHuntingSeasonsAsync();
    }
}

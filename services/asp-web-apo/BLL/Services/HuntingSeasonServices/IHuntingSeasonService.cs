using BLL.DTOs.HuntingSeason;
using BLL.Interfaces;

namespace BLL.Services.HuntingSeasonServices
{
    public interface IHuntingSeasonService : IBaseService<HuntingSeasonDetailDTO>
    {
        public Task<IEnumerable<HuntingSeasonDTO>> GetAllHuntingSeasonsAsync();
    }
}

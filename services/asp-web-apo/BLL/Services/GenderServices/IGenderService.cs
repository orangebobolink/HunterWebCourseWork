using BLL.DTOs.HuntingSeason;
using BLL.Interfaces;

namespace BLL.Services.GenderServices
{
    public interface IGenderService : IRepositoryService<GenderDTO>, IGetByNameService<GenderDTO>
    {
    }
}

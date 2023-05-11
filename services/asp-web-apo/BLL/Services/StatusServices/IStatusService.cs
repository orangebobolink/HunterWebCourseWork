using BLL.DTOs;

namespace BLL.Services.StatusServices
{
    public interface IStatusService
    {
        public Task<List<StatusDTO>> GetAll();
    }
}

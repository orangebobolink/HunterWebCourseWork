using BLL.DTOs;
using BLL.Interfaces;

namespace BLL.Services.MethodServices
{
    public interface IMethodService : IRepositoryService<MethodOfHuntingDTO>, IGetByNameService<MethodOfHuntingDTO>
    {
    }
}

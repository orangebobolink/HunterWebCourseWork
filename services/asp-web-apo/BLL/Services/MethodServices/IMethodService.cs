using BLL.DTOs.HuntingSeason;
using BLL.Interfaces;

namespace BLL.Services.MethodServices
{
    public interface IMethodService : IBaseService<MethodOfHuntingDTO>, IGetByNameService<MethodOfHuntingDTO>
    {
    }
}

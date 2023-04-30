using BLL.DTOs.HuntingSeason;
using BLL.Interfaces;

namespace BLL.Services.TypeServices
{
    public interface ITypeService : IBaseService<TypeOfHuntingDTO>, IGetByNameService<TypeOfHuntingDTO>
    {
    }
}

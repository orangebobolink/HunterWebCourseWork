using BLL.DTOs;
using BLL.Interfaces;

namespace BLL.Services.TypeServices
{
    public interface ITypeService : IRepositoryService<TypeOfHuntingDTO>, IGetByNameService<TypeOfHuntingDTO>
    {
    }
}

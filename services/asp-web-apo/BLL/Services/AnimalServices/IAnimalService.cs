using BLL.DTOs.Animal;
using BLL.Interfaces;

namespace BLL.Services.AnimalServices
{
    public interface IAnimalService
    {
        public Task<IEnumerable<AnimalDTO>> GetAllAsync();
        public Task<AnimalDetailDTO?> GetByIdAsync(int id);
        public Task<AnimalDetailDTO?> GetByNameAsync(string name);
        public Task<AnimalDetailDTO?> GetByEnglishNameAsync(string name);
        public Task<AnimalDetailDTO> AddAsync(AnimalDetailDTO item);
        public Task<AnimalDetailDTO> UpdateAsync(AnimalDetailDTO item);
        public Task<AnimalDetailDTO> RemoveAsync(AnimalDetailDTO item);
    }
}

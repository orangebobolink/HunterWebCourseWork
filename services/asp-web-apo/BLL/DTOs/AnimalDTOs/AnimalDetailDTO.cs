using BLL.DTOs.HuntingSeason;

namespace BLL.DTOs.Animal
{
    public class AnimalDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TableId { get; set; } = string.Empty;
        // TODO: тут поменять на huntingseasonDTO и сервис изменить
        public List<HuntingSeasonDetailDTO> HuntingSeasons { get; set; } = new List<HuntingSeasonDetailDTO>();
    }
}

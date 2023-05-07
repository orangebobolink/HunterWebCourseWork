using DAL.Entities.HuntingSeasonEntities;

namespace DAL.Entities.AnimalEntities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int AnimalDetailId { get; set; }
        public AnimalDetail? AnimalDetail { get; set; }
        public List<HuntingSeason> HuntingSeasons { get; set; } = new();
    }
}

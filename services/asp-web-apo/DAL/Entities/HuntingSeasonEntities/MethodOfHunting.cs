namespace DAL.Entities.HuntingSeasonEntities
{
    public class MethodOfHunting
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<HuntingSeasonDetail> HuntingSeasonDetails { get; set; } = new List<HuntingSeasonDetail>();
    }
}
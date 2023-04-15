namespace DAL.Entities.HuntingSeasonEntities
{
    public class HuntingSeasonDetail
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? TypeOfHuntingId { get; set; }
        public TypeOfHunting? TypeOfHunting { get; set; }
        public int? MethodOfHuntingId { get; set; }
        public MethodOfHunting? MethodOfHunting { get; set; }
        /// <summary>
        /// Тип времени: до полудня, в ночное время, в дневное время
        /// </summary>
        public string HuntingTime { get; set; } = string.Empty;
        /// <summary>
        /// Сезон охоты может проходить на оба пола, в таком случае пол будет "Любой"
        /// </summary>
        public int? GenderId { get; set; }
        public Gender? Gender { get; set; }
        /// <summary>
        /// Формат возраста: больше 12 лет, меньше 7 лет и тд
        /// </summary>
        public string Age { get; set; }
    }
}

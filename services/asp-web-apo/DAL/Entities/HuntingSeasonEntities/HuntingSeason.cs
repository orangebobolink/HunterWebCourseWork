using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.HuntingSeasonEntities
{
    public class HuntingSeason
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; } // TODO: сделать так чтоб выдовала только день и месяц
        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; } // TODO: сделать так чтоб выдовала только день и месяц
        public int HuntingSeasonDetailId { get; set; }
        public HuntingSeasonDetail? HuntingSeasonDetail { get; set; } = new HuntingSeasonDetail();
    }
}

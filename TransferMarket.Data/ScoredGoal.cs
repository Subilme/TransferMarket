using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferMarket.Data
{
    [Table("ScoredGoals")]
    public class ScoredGoal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [ForeignKey(nameof(PlayerScored))]
        public int PlayerScoredId { get; set; }

        [Column]
        public int Time { get; set; }

        public Game Game { get; set; }
        public Player PlayerScored { get; set; }
    }
}

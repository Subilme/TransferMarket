using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferMarket.Data
{
    [Table("Games")]
    public class Game
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }

        [ForeignKey(nameof(GuestTeam))]
        public int GuestTeamId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }

        [InverseProperty(nameof(ScoredGoal.Game))]
        public virtual ICollection<ScoredGoal> ScoredGoals { get; set; } = new HashSet<ScoredGoal>();

        [InverseProperty(nameof(Card.Game))]
        public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}

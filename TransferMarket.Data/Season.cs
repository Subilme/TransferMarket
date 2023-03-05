using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferMarket.Data
{
    [Table("Seasons")]
    public class Season
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(BestStriker))]
        public int BestStrikerId { get; set; }

        [ForeignKey(nameof(BestAssistant))]
        public int BestAssistantId { get; set; }

        [ForeignKey(nameof(Winner))]
        public int WinnerId { get; set; }

        public Tournament Tournament { get; set; }
        public Player BestStriker { get; set; }
        public Player BestAssistant { get; set; }
        public Team Winner { get; set; }

        [InverseProperty(nameof(Team.Season))]
        public virtual ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}

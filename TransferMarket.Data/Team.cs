using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferMarket.Data
{
    [Table("Teams")]
    public class Team
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }

        [Column]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalCost { get; set; }

        public Season Season { get; set; }

        [InverseProperty(nameof(Player.Team))]
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}

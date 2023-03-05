using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferMarket.Data
{
    [Table("Players")]
    public class Player
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }

        [Column]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [ForeignKey(nameof(Amplification))]
        public int AmplififcationId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public Team? Team { get; set; }
        public Amplification Amplification { get; set; }
    }
}

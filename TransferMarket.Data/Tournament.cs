using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferMarket.Data
{
    [Table("Tournaments")]
    public class Tournament
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column]
        [StringLength(255)]
        public string Name { get; set; }

        [InverseProperty(nameof(Season.Tournament))]
        public virtual ICollection<Season> Seasons { get; set; } = new HashSet<Season>();
    }
}

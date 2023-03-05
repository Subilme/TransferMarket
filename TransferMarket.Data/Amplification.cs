using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferMarket.Data
{
    [Table("Amplifications")]
    public class Amplification
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

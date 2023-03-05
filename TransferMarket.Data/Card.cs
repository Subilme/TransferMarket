using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferMarket.Data
{
    [Table("Cards")]
    public class Card
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(CardType))]
        public int CardTypeId { get; set; }

        public Game Game { get; set; }
        public Player Player { get; set; }
        public CardType CardType { get; set; }
    }
}

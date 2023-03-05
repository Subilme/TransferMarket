using Microsoft.EntityFrameworkCore;
using TransferMarket.Data;

namespace TransferMarket.App.Services.Impl
{
    public class CardRepository : ICardRepository
    {
        private readonly TransferMarketDbContext _context;

        public CardRepository(TransferMarketDbContext context)
        {
            _context = context;
        }

        public IList<Card> GetAll()
        {
            return _context.Cards
                .Include(x => x.CardType).ToList();
        }

        public Card? GetById(int id)
        {
            return _context.Cards
                .Include(x => x.CardType).FirstOrDefault(x => x.Id == id);
        }

        public int Create(Card data)
        {
            _context.Cards.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public bool Delete(int id)
        {
            var card = GetById(id);
            if (card != null)
            {
                _context.Cards.Remove(card);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(Card data)
        {
            var card = GetById(data.Id);
            if (card != null)
            {
                card.GameId = data.GameId;
                card.PlayerId = data.PlayerId;
                card.CardTypeId = data.CardTypeId;

                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}

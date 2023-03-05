using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TransferMarket.Data;

namespace TransferMarket.App.Services.Impl
{
    public class GameRepository : IGameRepository
    {
        private readonly TransferMarketDbContext _context;

        public GameRepository(TransferMarketDbContext context)
        {
            _context = context;
        }

        public IList<Game> GetAll()
        {
            return _context.Games.OrderBy(x => x.Date)
                .Include(x => x.HomeTeam.Players)
                .Include(x => x.GuestTeam.Players)
                .Include(x => x.ScoredGoals).ToList();
        }

        public Game? GetById(int id)
        {
            return _context.Games.FirstOrDefault(x => x.Id == id);
        }

        public int Create(Game data)
        {
            _context.Games.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public bool Delete(int id)
        {
            var game = GetById(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(Game data)
        {
            var game = GetById(data.Id);
            if (game != null)
            {
                game.HomeTeamId = data.HomeTeamId;
                game.GuestTeamId = data.GuestTeamId;

                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}

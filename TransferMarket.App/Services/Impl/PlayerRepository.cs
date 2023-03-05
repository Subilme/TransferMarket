using Microsoft.EntityFrameworkCore;
using TransferMarket.Data;

namespace TransferMarket.App.Services.Impl
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly TransferMarketDbContext _context;

        public PlayerRepository(TransferMarketDbContext context)
        {
            _context = context;
        }

        public IList<Player> GetAll()
        {
            return _context.Players.OrderByDescending(x => x.Price)
                .Include(x => x.Team).ToList();
        }

        public Player? GetById(int id)
        {
            return _context.Players
                .Include(x => x.Amplification)
                .Include(x => x.Team).FirstOrDefault(x => x.Id == id);
        }

        public int Create(Player data)
        {
            data.TeamId = _context.Teams.FirstOrDefault(x => x.Name == data.Team!.Name)!.Id;
            data.Team = _context.Teams.FirstOrDefault(x => x.Id == data.TeamId);
            data.AmplififcationId = _context.Amplifications.FirstOrDefault(x => x.Name == data.Amplification.Name)!.Id;

            _context.Players.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public bool Delete(int id)
        {
            var player = GetById(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(Player data)
        {
            data.TeamId = _context.Teams.FirstOrDefault(x => x.Name == data.Team!.Name)!.Id;
            data.Team = _context.Teams.FirstOrDefault(x => x.Id == data.TeamId);
            data.AmplififcationId = _context.Amplifications.FirstOrDefault(x => x.Name == data.Amplification.Name)!.Id;

            var player = GetById(data.Id);
            if (player != null)
            {
                player.Name = data.Name;
                player.TeamId = data.TeamId;
                player.Birthday = data.Birthday;
                player.Price = data.Price;
                player.AmplififcationId = data.AmplififcationId;

                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}

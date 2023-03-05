using Microsoft.EntityFrameworkCore;
using TransferMarket.Data;

namespace TransferMarket.App.Services.Impl
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TransferMarketDbContext _context;

        public TeamRepository(TransferMarketDbContext context)
        {
            _context = context;
        }

        public IList<Team> GetAll()
        {
            return _context.Teams.OrderByDescending(x => x.TotalCost).ToList();
        }

        public Team? GetById(int id)
        {
            return _context.Teams
                .Include(x => x.Players).FirstOrDefault(x => x.Id == id);
        }

        public int Create(Team data)
        {
            _context.Teams.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public bool Delete(int id)
        {
            var team = GetById(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(Team data)
        {
            var team = GetById(data.Id);
            if (team != null)
            {
                team.Name = data.Name;
                team.SeasonId = data.SeasonId;
                team.TotalCost = data.TotalCost;

                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}

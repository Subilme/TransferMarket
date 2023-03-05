using Microsoft.EntityFrameworkCore;

namespace TransferMarket.Data
{
    public class TransferMarketDbContext : DbContext
    {
        public DbSet<Amplification> Amplifications { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<ScoredGoal> ScoredGoals { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        public TransferMarketDbContext(DbContextOptions options) : base(options) { }
    }
}

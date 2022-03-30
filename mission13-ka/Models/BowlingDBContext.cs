using Microsoft.EntityFrameworkCore;

namespace mission13_ka.Models
{
    public class BowlingDBContext : DbContext
    {
        public BowlingDBContext(DbContextOptions<BowlingDBContext> options) : base(options)
        {
        }

        public BowlingDBContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Settings.ConnectionString);
            }
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Bowler_Score> Bowler_Scores { get; set; }
        public DbSet<Match_Game> Match_Games { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Tourney_Match> Tourney_Matches { get; set; }
    }

    public static class Settings
    {
        public static string ConnectionString { get; set; }
    }
}

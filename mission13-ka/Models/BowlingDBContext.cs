using Microsoft.EntityFrameworkCore;

namespace mission13_ka.Models
{
    public class BowlingDBContext : DbContext
    {
        public BowlingDBContext(DbContextOptions<BowlingDBContext> options) : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}

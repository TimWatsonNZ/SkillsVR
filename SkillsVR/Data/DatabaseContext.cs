using Microsoft.EntityFrameworkCore;

namespace SkillsVR.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Team> Teams => Set<Team>();
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>()
                .HasIndex(team => team.Name)
                .IsUnique();
        }
    }
}

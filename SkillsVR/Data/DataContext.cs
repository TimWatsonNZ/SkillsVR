using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SkillsVR.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

    }

    public class Player
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string PlaceOfBirth { get; set; }
        public Team Team { get; set; }
    }

    public class Team
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        
        public string Name { get; set; }
        public string Ground { get; set; }
        public string Coach { get; set; }
        public DateTime FoundedYear { get; set; }
        public string Region { get; set; }
    }
}

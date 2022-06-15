using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SkillsVR.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<PlayerContract> PlayerContracts => Set<PlayerContract>();

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

    public class PlayerContract
    {
        [Key]
        public int Id { get; set; }

        public Player Player { get; set; }
        public Team Team { get; set; }
        public PlayerTeamState State { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public enum PlayerTeamState
    {
        Signed,
        Unsigned,
    }
}

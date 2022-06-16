using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SkillsVR.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Team> Teams => Set<Team>();
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

    }

    public class Player
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string PlaceOfBirth { get; set; } = null!;
        public int? TeamId { get; set; }

        [JsonIgnore]
        public virtual Team? Team { get; set; }
    }

    public class Team
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(100)]
        public string Ground { get; set; } = null!;
        [MaxLength(100)]
        public string Coach { get; set; } = null!;
        public DateTime FoundedYear { get; set; }
        public string Region { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Player>? Players { get; set; }
    }
}

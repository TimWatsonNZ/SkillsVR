using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SkillsVR.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

    }

    public class Player
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}

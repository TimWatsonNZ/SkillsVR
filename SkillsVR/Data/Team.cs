using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SkillsVR.Data
{
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
    }
}

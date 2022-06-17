using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SkillsVR.Data
{
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
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaRoboBuilder4.Data.Models
{
    [Table("PilotCard")]
    public class PilotCard
    {
        [Key]
        public int Id { get; set; }
        public int PilotId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }
        public int Cooldown { get; set; }
        public int MinRange { get; set; } //for pilot cards, min/Max ranges of 0 indicate the infinate sign in the range slot 
        public int MaxRange { get; set; }
        public string Requirements { get; set; }
        public string Rules { get; set; }
        public string MainArtImage { get; set; }
        public string CooldownImage { get; set; }
        public string DiceImage { get; set; }
        public string TypeImage { get; set; }
        public string LogoImage { get; set; }
    }
}

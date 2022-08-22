using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaRoboBuilder4.Data.Models
{
    [Table("RobotCard")]
    public class RobotCard
    {
        [Key]
        public int Id { get; set; }
        public int RobotId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public bool IsUltimate { get; set; }
        public string CardType { get; set; }
        public string SubType { get; set; }
        public int Cooldown { get; set; }
        public int BaseDamage { get; set; }
        public string DamageString { get; set; }
        public int AttackDice { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public string Requirements { get; set; }
        public string Rules { get; set; }
        public string MainArtImage { get; set; }
        public string CooldownImage { get; set; }
        public string DiceImage { get; set; }
        public string DamageImage { get; set; }
        public string TypeImage { get; set; }
        public string CounterImage { get; set; }
        public string ComboImage { get; set; }
        public string LogoImage { get; set; }
    }
}

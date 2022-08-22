using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaRoboBuilder4.Data.Models
{
    [Table("RobotAbility")]
    public class RobotAbility
    {
        [Key]
        public int Id { get; set; }
        public int RobotId { get; set; }
        public string Name { get; set; }
        public string Rules { get; set; }
        public int PowerTokens { get; set; }
        public string LogoImage { get; set; }
    }
}

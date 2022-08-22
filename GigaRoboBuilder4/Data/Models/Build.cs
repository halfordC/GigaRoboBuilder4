using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaRoboBuilder4.Data.Models
{
    [Table("Build")]
    public class Build
    {

        [Key]
        public int Id { get; set; }
        //public AppUser BuildOwner { get; set; }
        [Required]
        public string Name { get; set; }
        public Robot ChosenRobot { get; set; }
        public Pilot ChosenPilot { get; set; }
        public ICollection<RobotCard> RobotCardList { get; set; }
        public ICollection<PilotCard> PilotCardList { get; set; }
        public PilotAbility ChosenPilotAbility { get; set; }
        public ICollection<RobotAbility> RobotAbilityList { get; set; }
        public string Creator { get; set; }

        //methods to consider adding: Build Verification. Is this a valid build? Does it meet all requirnments?
    }
}

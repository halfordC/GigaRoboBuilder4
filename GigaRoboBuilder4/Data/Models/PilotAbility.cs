using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaRoboBuilder4.Data.Models
{
    [Table("PilotAbility")]
    public class PilotAbility
    {
        [Key]
        public int Id { get; set; }
        public int PilotId { get; set; }
        public string Name { get; set; }
        public string Rules { get; set; }

        public string MainArtImage { get; set; }
        public string LogoImage { get; set; }
    }
}

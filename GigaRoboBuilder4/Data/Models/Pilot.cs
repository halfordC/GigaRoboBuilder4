using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaRoboBuilder4.Data.Models
{
    [Table("Pilot")]
    public class Pilot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Heart { get; set; }
        public int Rage { get; set; }
        public int Power { get; set; }
        public int MaxFightingSpirit { get; set; }
        public string MainImage { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaRoboBuilder4.Data.Models
{
    [Table("Robot")]
    public class Robot
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public int MaxArmour { get; set; }
        public int Defence { get; set; }

        public string MainImage { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace mission13_ka.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
    }
}

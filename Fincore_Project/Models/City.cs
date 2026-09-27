using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [StringLength(30)]
        public string CityName { get; set; }

        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }

        public State State { get; set; }
    }
}
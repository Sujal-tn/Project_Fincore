using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required]
        [StringLength(30)]
        public string StateName { get; set; }

        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public List<City> Cities { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Fincore_Project.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }

        [Required]
        [StringLength(20)]
        public string CurrencyName { get; set; }

        [StringLength(5)]
        public string Symbol { get; set; }
        public List<Country> Countries { get; set; }
    }
}

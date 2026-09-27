namespace Fincore_Project.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public int CountryCode { get; set; }

        [Required]
        [StringLength(30)]
        public string CountryName { get; set; }

        [Required]
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }

        public List<Company> Companies { get; set; }

        public List<State> States { get; set; }
    }
}
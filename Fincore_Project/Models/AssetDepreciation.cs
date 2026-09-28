using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class AssetDepreciation
    {
        [Key]
        public int AssetDepreciationId { get; set; }


        // Asset
        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public Asset Asset { get; set; }


        // Depreciation Information
        [Required]
        public DateTime DepreciationDate { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal OpeningValue { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal DepreciationAmount { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal ClosingValue { get; set; }


        [StringLength(50)]
        public string DepreciationMethod { get; set; }


        public int? UsefulLifeYears { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalvageValue { get; set; }


        [StringLength(20)]
        public string Status { get; set; }


        // Audit
        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}

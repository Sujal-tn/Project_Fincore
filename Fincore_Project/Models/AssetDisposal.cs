using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class AssetDisposal
    {
        [Key]
        public int AssetDisposalId { get; set; }


        // Asset
        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public Asset Asset { get; set; }


        // Disposal Information
        [Required]
        public DateTime DisposalDate { get; set; }


        [Required]
        [StringLength(150)]
        public string DisposalReason { get; set; }


        [StringLength(100)]
        public string DisposalMethod { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal BookValue { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal DisposalValue { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal GainOrLoss { get; set; }


        [StringLength(20)]
        public string Status { get; set; }


        [StringLength(500)]
        public string Remarks { get; set; }


        // Audit
        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class AssetLocation
    {
        [Key]
        public int AssetLocationId { get; set; }


        // Asset
        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public Asset Asset { get; set; }


        // Location Information
        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(100)]
        public string Building { get; set; }

        [StringLength(50)]
        public string Floor { get; set; }

        [StringLength(100)]
        public string Room { get; set; }


        // Location History
        [Required]
        public DateTime EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }


        [StringLength(500)]
        public string Remarks { get; set; }


        // Audit
        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}

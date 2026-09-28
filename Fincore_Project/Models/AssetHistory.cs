using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class AssetHistory
    {
        [Key]
        public int AssetHistoryId { get; set; }


        // Asset
        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public Asset Asset { get; set; }


        // Action Information
        [Required]
        [StringLength(100)]
        public string Action { get; set; }


        [StringLength(500)]
        public string Description { get; set; }


        [StringLength(50)]
        public string PreviousStatus { get; set; }


        [StringLength(50)]
        public string NewStatus { get; set; }


        // User who performed the action
        [ForeignKey("PerformedByUser")]
        public int? PerformedBy { get; set; }

        public User PerformedByUser { get; set; }


        [Required]
        public DateTime ActionDate { get; set; }
    }
}

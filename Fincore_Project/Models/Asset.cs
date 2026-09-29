using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Fincore_Project.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        [StringLength(50)]
        public string AssetCode { get; set; }

        [Required]
        [StringLength(40)]
        public string AssetName { get; set; }

        [ForeignKey("CapexRequest")]
        public int? CapexRequestId { get; set; }
        public CapexRequest CapexRequest { get; set; }

        [ForeignKey("PurchaseOrder")]
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        [ForeignKey("GRN")]
        public int? GRNId { get; set; }
        public GRN GRN { get; set; }

        [ForeignKey("Vendor")]
        public int? VendorId { get; set; }
        public Vendor Vendor { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public DateTime? PurchaseDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchaseCost { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public List<AssetAssignment> AssetAssignments { get; set; }

        public List<AssetLocation> AssetLocations { get; set; }

        public List<AssetDepreciation> AssetDepreciations { get; set; }

        public List<AssetDisposal> AssetDisposals { get; set; }

        public List<AssetHistory> AssetHistories { get; set; }
    }
}

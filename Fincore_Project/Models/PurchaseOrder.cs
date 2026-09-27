using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int POItemId { get; set; }

        [Required]
        [ForeignKey("PurchaseOrder")]
        public int POId { get; set; }
        public PurchaseOrder PurchaseOrders { get; set; }

        [Required]
        [ForeignKey("PurchaseRequisitionItem")]
        public int PRItemId { get; set; }
        public PurchaseRequisitionItem PurchaseRequisitionItem { get; set; }

        [Required]
        [StringLength(40)]
        public string ItemName { get; set; }

        [StringLength(500)]
        public string ItemDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(20)]
        public string UnitOfMaterial { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TaxPercentage { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LineTotal { get; set; }

        [Required]
        [StringLength(10)]
        public string ItemStatus { get; set; }

        public List<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public List<GRN> GRNs { get; set; }
        //public List<Asset> Assets { get; set; }
        //public List<APInvoice> APInvoices { get; set; }
    }
}

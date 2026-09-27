using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class PurchaseOrderItem
    {
        public PurchaseRequisitionItem PurchaseRequisitionItem { get; set; }
        [ForeignKey("PurchaseRequisitionItem")]
        public int? PRItemId { get; set; }
    }
}

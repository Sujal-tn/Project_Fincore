using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Fincore_Project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

     
        [ForeignKey("Role")]
        public int? RoleId { get; set; } 

        public Role? Roles { get; set; } 

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string PasswordHash { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        public DateTime? LastLogin { get; set; }

        public string? UserCategory { get; set; }

        public string? RefreshToken { get; set; }

        [Required]
        public byte IsActive { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }


        public List<RevenueEntry> RevenueEntriesCreated {  get; set; }
        public List<RevenueEntry> RevenueEntriesModified { get; set; }
        public List<ARInvoice> ARInvoicesCreated { get; set; }     
        public List<ARInvoice> ARInvoicesModified { get; set; }
        public List<AccountMaster> AccountMastersCreated { get; set; }
        public List<AccountMaster> AccountMastersModified { get; set; }
        public List<JournalEntry> JournalEntriesCreated { get; set; }
        public List<JournalEntry> JournalEntriesModified { get; set; }

        public List<Vendor> VendorsCreated { get; set; }
        public List<Vendor> VendorsModified { get; set; }
        public List<DocumentType> DocumentTypesCreated { get; set; }
        public List<DocumentType> DocumentTypesModified { get; set; }
        public List<VendorDocument> Documents { get; set; }
        public List<VendorCategory> VendorCategoriesCreated { get; set; }
        public List<VendorCategory> VendorCategoriesModified { get; set; }
        public List<PurchaseRequisition> PurchaseRequisitionsRequested { get; set; }
        public List<PurchaseRequisition> PurchaseRequisitionsApproved { get; set; }
        public List<PurchaseRequisition> PurchaseRequisitionsCreated { get; set; }
        public List<PurchaseRequisition> PurchaseRequisitionsModified { get; set; }
        public List<PurchaseOrder> PurchaseOrdersRequested { get; set; }
        public List<PurchaseOrder> PurchaseOrdersApproved { get; set; }
        public List<PurchaseOrder> PurchaseOrdersCreated { get; set; }
        public List<PurchaseOrder> PurchaseOrdersModified { get; set; }
        public List<GRN> GRNsReceived { get; set; }
        public List<GRN> GRNsQualityChecked { get; set; }
        public List<WorkOrder> WorkOrdersCreated { get; set; }
        public List<VendorSelection> VendorSelectionsSelected { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class RevenueEntry
    {
        [Key]
        public int RevenueEntryId { get; set; }
        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        [StringLength(20)]
        public string RevenueType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime RevenueDate { get; set; }


        [ForeignKey("AccountMaster")]
        public int AccountId { get; set; }
        public AccountMaster AccountMaster { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }


        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }

     
        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }
        public User? ModifiedByUser { get; set; }


        //Navigation

        public List<ARInvoice> ARInvoices { get; set; }
    }
}

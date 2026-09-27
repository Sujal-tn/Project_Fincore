using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class ARInvoice
    {
        [Key]
        public int ARInvoiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("RevenueEntry")]
        public int RevenueEntryId { get; set; }
        public RevenueEntry RevenueEntry { get; set; }

        public DateTime InvoiceDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AmountReceived { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AmountOutstanding { get; set; }

        [StringLength(20)]
        public string PaymentStatus { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }


        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }


        [ForeignKey("ModifiedByUser")]
        public int ModifiedBy { get; set; }
        public User ModifiedByUser { get; set; }
    }
}

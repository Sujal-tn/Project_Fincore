using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class RFQVendor
    {
        [Key]
        public int RFQVendorId { get; set; }

        [Required]
        [ForeignKey("RFQ")]
        public int RFQId { get; set; }
        public RFQ RFQ { get; set; }

        [Required]
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public DateTime? InvitedAt { get; set; }

        [Required]
        [StringLength(20)]
        public string ResponseStatus { get; set; }


    }
}

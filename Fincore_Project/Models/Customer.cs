using System.ComponentModel.DataAnnotations;

namespace Fincore_Project.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public List<ARInvoice> ARInvoices { get; set; }
        public List<Payment> Payments { get; set; }
       

        [Required]
        [StringLength(30)]
        public string CustomerCode { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public byte IsActive { get; set; }

     
    }
}
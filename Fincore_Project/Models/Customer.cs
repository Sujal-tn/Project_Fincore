using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class Customer
    {
<<<<<<< HEAD
=======


>>>>>>> 3eec8db17ee3802c886a8ecb2c187ff6728f8d2c
        [Key]
        public int CustomerId { get; set; }

        public List<RevenueEntry> RevenueEntries {  get; set; }

        public List<ARInvoice> ARInvoices { get; set; }
<<<<<<< HEAD
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
=======

        //Navigation
        public List<Payment> Payments { get; set; }
>>>>>>> 3eec8db17ee3802c886a8ecb2c187ff6728f8d2c
    }
}
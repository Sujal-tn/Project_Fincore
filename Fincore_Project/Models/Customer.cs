using System.ComponentModel.DataAnnotations;

namespace Fincore_Project.Models
{
    public class Customer
    {


        [Key]
        public int CustomerId { get; set; }

        public List<RevenueEntry> RevenueEntries {  get; set; }

        public List<ARInvoice> ARInvoices { get; set; }

        //Navigation
        public List<Payment> Payments { get; set; }
<<<<<<< HEAD
=======
       

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

<<<<<<< HEAD
=======
     
>>>>>>> 12ff8e30522fc63e20b37e6fd8c0be62f9bedb96
>>>>>>> 3bbe8b6d68d6c40d139a90cd7e2c9d8c1ce54c8c
    }
}
using System.ComponentModel.DataAnnotations;

namespace Fincore_Project.Models
{
    public class Customer
    {


        [Key]
        public int CustomerId { get; set; }

        public List<RevenueEntry> RevenueEntries {  get; set; }

        public List<ARInvoice> ARInvoices { get; set; }
    }
}
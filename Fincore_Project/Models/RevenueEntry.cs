using System.ComponentModel.DataAnnotations;

namespace Fincore_Project.Models
{
    public class RevenueEntry
    {
        [Key]
        public int RevenueEntryId { get; set; }

        public List<ARInvoice> ARInvoices { get; set; }
    }
}

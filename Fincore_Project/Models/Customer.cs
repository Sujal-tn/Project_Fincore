namespace Fincore_Project.Models
{
    public class Customer
    {
        public List<ARInvoice> ARInvoices { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
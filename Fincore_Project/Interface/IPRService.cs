using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IPRService
    {
        Task AddPR(PurchaseRequisition pr);
        Task<List<CapexRequest>> GetCapexRequests();
        Task<List<Vendor>> GetVendors();
        Task<List<User>> GetUsers();
    }
}

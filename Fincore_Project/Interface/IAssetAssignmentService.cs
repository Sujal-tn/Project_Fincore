using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IAssetAssignmentService
    {
        Task AddAssignment(AssetAssignment a);
        Task<List<AssetAssignment>> FetchAssignment();
        Task<List<Asset>> FetchAll();
        Task<List<Employee>> FecthAll();
    }
}

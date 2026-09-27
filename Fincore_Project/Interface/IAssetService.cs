using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IAssetService
    {
        Task AddAsset(Asset a);
        Task DeleteAsset(int id);
        Task UpdateAsset(Asset a);
        Task<List<Asset>> FetchAll();
        Task<Asset> FetchById(int id);
    }
}

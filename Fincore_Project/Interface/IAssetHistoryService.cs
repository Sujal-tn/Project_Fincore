using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IAssetHistoryService
    {
        Task AddHistory(AssetHistory h);
        Task<List<AssetHistory>> FetchAll();
        Task<List<Asset>> FetchAsset();
        Task<List<User>> FetchUser();
    }
}

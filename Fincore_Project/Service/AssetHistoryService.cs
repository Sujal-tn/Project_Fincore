using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;


namespace Fincore_Project.Service
{
    public class AssetHistoryService : IAssetHistoryService
    {
        ApplicationDbContext db;
        public AssetHistoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddHistory(AssetHistory h)
        {
            await db.AssetHistories.AddAsync(h);
            await db.SaveChangesAsync();
        }

        public async Task<List<AssetHistory>> FetchAll()
        {
            var hlist = await db.AssetHistories
                .OrderByDescending(x => x.ActionDate)
                .ToListAsync();
            return hlist;
        }

        public async Task<List<Asset>> FetchAsset()
        {
            var a = await db.Assets.ToListAsync();
            return a;
        }

        public async Task<List<User>> FetchUser()
        {
            var u = await db.Users.ToListAsync();
            return u;
        }
    }
}

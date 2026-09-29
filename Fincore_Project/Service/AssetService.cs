using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Service
{
    public class AssetService : IAssetService
    {
        ApplicationDbContext db;
        public AssetService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddAsset(Asset a)
        {
            await db.Assets.AddAsync(a);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsset(int id)
        {
            var del = await db.Assets.FindAsync(id);
            if (del != null)
            {
                db.Assets.Remove(del);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Asset>> FetchAll()
        {
            var a = await db.Assets.ToListAsync();
            return a;
        }

        public async Task<Asset> FetchById(int id)
        {
            var ast = await db.Assets.FindAsync();
            return ast;
        }

        public async Task<List<Department>> FetchDepartments()
        {
            var d = await db.Departments.ToListAsync();
            return d;
        }

        public async Task<List<Vendor>> FetchVendors()
        {
            var v = await db.Venders.ToListAsync();
            return v;
        }

        public async Task UpdateAsset(Asset a)
        {
            db.Assets.Update(a);
            await db.SaveChangesAsync();
        }
    }
}

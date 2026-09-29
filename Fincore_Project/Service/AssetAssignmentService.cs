using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Service
{
    public class AssetAssignmentService : IAssetAssignmentService
    {
        ApplicationDbContext db;
        public AssetAssignmentService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddAssignment(AssetAssignment a)
        {
            await db.AssetAssignments.AddAsync(a);
            await db.SaveChangesAsync();
        }

        public async Task<List<Employee>> FecthAll()
        {
            var e = await db.Employees.ToListAsync();
            return e;
        }

        public async Task<List<Asset>> FetchAll()
        {
            var ass = await db.Assets.ToListAsync();
            return ass;
        }

        public async Task<List<AssetAssignment>> FetchAssignment()
        {
            var assign = await db.AssetAssignments.ToListAsync();
            return assign;
        }
    }
}

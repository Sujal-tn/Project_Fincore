using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Service
{
    public class PRService: IPRService
    {
        ApplicationDbContext db;
        public PRService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddPR(PurchaseRequisition pr)
        {
            await db.PurchaseRequisition.AddAsync(pr);
            await db.SaveChangesAsync();
        }

        public async Task<List<CapexRequest>> GetCapexRequests()
        {
            return await db.CapexRequests
            .ToListAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await db.Users
           .Where(x => x.IsActive == 1)
           .ToListAsync();
        }

        public async Task<List<Vendor>> GetVendors()
        {
            return await db.Venders
             .Where(x => x.IsActive == 1)
             .ToListAsync();
        }
    }
}

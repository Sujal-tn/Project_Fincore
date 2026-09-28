using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fincore_Project.Service
{
    public class VendorCategoryService: IVendorCategoryService
    {
        ApplicationDbContext db;
        public VendorCategoryService(ApplicationDbContext db)
        {
            this.db = db;

        }

        public async Task AddDocumentType(DocumentType dt)
        {
            //dt.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            //dt.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            dt.CreatedBy = 3;
            dt.ModifiedBy = 3;
            dt.CreatedAt = DateTime.Now;
            await db.DocumentType.AddAsync(dt);
            await db.SaveChangesAsync();
        }

        public async Task AddVendorCategory(VendorCategory v)
        {
            //v.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            //v.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            v.CreatedBy = 3;
            v.ModifiedBy = 3;
            v.CreatedAt = DateTime.Now;
            await db.VendorCategory.AddAsync(v);
            await db.SaveChangesAsync();
        }


    }
}

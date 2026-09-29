using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata;

namespace Fincore_Project.Service
{
    public class VendorCategoryService: IVendorCategoryService
    {
        ApplicationDbContext db;
        IWebHostEnvironment environment;
        public VendorCategoryService(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }

        public async Task AddDocumentType(DocumentType dt)
        {
            //dt.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            //dt.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            dt.CreatedBy = 1;
            dt.ModifiedBy = 1;
            dt.CreatedAt = DateTime.Now;
            await db.DocumentType.AddAsync(dt);
            await db.SaveChangesAsync();
        }

        public async Task AddVendorCategory(VendorCategory v)
        {
            //v.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            //v.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            v.CreatedBy = 1;
            v.ModifiedBy = 1;
            v.CreatedAt = DateTime.Now;
            await db.VendorCategory.AddAsync(v);
            await db.SaveChangesAsync();
        }

        public async Task<List<DocumentType>> getDocumentType()
        {
            return await db.DocumentType
                .Where(x => x.IsActive == 1)
                .ToListAsync();
        }

        public async Task<List<MasterType>> getMasterType()
        {
            return await db.MasterTypes.ToListAsync();
        }

        public async Task<List<User>> getUsers()
        {
            return await db.Users
                .Where(x => x.IsActive == 1)
                .ToListAsync();
        }

        public async Task<List<Vendor>> getVendors()
        {
            return await db.Venders
                .Where(x => x.IsActive == 1)
                .ToListAsync();
        }

        public async Task AddDocument(VendorDocument vd, IFormFile documentFile)
        {
            if (documentFile != null && documentFile.Length > 0)
            {
                // Folder path
                string folder = Path.Combine(environment.WebRootPath, "VendorDocuments");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                // Unique filename
                string uniqueFileName = Guid.NewGuid().ToString()
                                      + Path.GetExtension(documentFile.FileName);

                string fullPath = Path.Combine(folder, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await documentFile.CopyToAsync(stream);
                }

                vd.FileName = documentFile.FileName;
                vd.FilePath = "/VendorDocuments/" + uniqueFileName;
                vd.FileType = documentFile.ContentType;
            }

            vd.CreatedAt = DateTime.Now;
            vd.ModifiedAt = DateTime.Now;
            await db.VendorDocument.AddAsync(vd);
            await db.SaveChangesAsync();
        }

        public async Task AddVendor(Vendor v)
        {
            //v.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            //v.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            v.CreatedBy = 1;
            v.ModifiedBy = 1;
            await db.Venders.AddAsync(v);
            await db.SaveChangesAsync();

        }

        public async Task<List<VendorCategory>> getVendorCategory()
        {
            return await db.VendorCategory.ToListAsync();
        }

        public async Task<List<Company>> getCompany()
        {
            return await db.Companies.ToListAsync();
        }

        public async Task<List<Vendor>> FetchVendors()
        {
           return await db.Venders
                .Include(x => x.VendorCategory)
                .Include(x => x.Company)
                .ToListAsync();
        }

        public async Task DelVendor(int id)
        {
           var vid= await db.Venders.FindAsync(id);
           db.Venders.Remove(vid);
           await db.SaveChangesAsync();

        }

        public async Task<Vendor> getVendorById(int id)
        {
            return await db.Venders.FindAsync(id);
        }

        public async Task UpdateVendor(Vendor v)
        {
            var data = await db.Venders.FindAsync(v.VendorId);

            if (data != null)
            {
                data.VendorCode = v.VendorCode;
                data.VendorCategoryId = v.VendorCategoryId;
                data.CompanyId = v.CompanyId;
                data.BankAccount = v.BankAccount;
                data.PAN = v.PAN;
                data.IsActive = v.IsActive;

                data.ModifiedAt = DateTime.Now;
                data.ModifiedBy = 1;

                await db.SaveChangesAsync();
            }
        }

        public async Task DelVendorCategory(int id)
        {
            var data = await db.VendorCategory.FindAsync(id);
            db.VendorCategory.Remove(data);
            await db.SaveChangesAsync();

        }

        public async Task<VendorCategory> getVendorCategoryById(int id)
        {
            return await db.VendorCategory.FindAsync(id);
        }

        public async Task UpdateVendorCategory(VendorCategory v)
        {
            var data = await db.VendorCategory.FindAsync(v.VendorCategoryId);

            if (data != null)
            {
                data.CategoryName = v.CategoryName;
                data.Description = v.Description;
                data.IsActive = v.IsActive;

                data.ModifiedAt = DateTime.Now;
                data.ModifiedBy = 1;

                await db.SaveChangesAsync();
            }
        }

        public async Task<List<VendorDocument>> FetchVendorDocument()
        {
           return await db.VendorDocument
                .Include(x => x.Vendor)
                .Include(u => u.User)
                .Include(d => d.DocumentType)
                .Include(m => m.MasterType)
                .ToListAsync();
        }

        public async Task DelVendorDocument(int id)
        {
            var data=await db.VendorDocument.FindAsync(id);
            db.VendorDocument.Remove(data);
            await db.SaveChangesAsync();
        }

        public Task<VendorDocument> getVendorDocumentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVendorDocument(VendorDocument v)
        {
            throw new NotImplementedException();
        }
    }
}

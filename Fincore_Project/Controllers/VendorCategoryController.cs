using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fincore_Project.Controllers
{
    public class VendorCategoryController : Controller
    {
        IVendorCategoryService service;
        public VendorCategoryController(IVendorCategoryService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> AddVendorCategory()
        {
            var data = await service.getVendorCategory();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddVendorCategory(VendorCategory v)
        {
            await service.AddVendorCategory(v);
            return new JsonResult("");
        }

        public IActionResult AddDocumentType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDocumentType(DocumentType d)
        {
            await service.AddDocumentType(d);
            return new JsonResult("");
        }


        public async Task<IActionResult> AddDocument()
        {
            var data =await service.FetchVendorDocument();
            ViewBag.Vendors = new SelectList(await service.getVendors(),
                                     "VendorId",
                                     "VendorCode");

            ViewBag.Users = new SelectList(await service.getUsers(),
                                           "UserId",
                                           "FullName");

            ViewBag.DocumentTypes = new SelectList(await service.getDocumentType(),
                                                  "DocumentTypeId",
                                                  "DocumentCategory");

            ViewBag.MasterTypes = new SelectList(await service.getMasterType(),
                                                "MasterTypeId",
                                                "MasterTypeName");


            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddDocument(VendorDocument v)
        {
            await service.AddDocument(v, v.File);
            return new JsonResult("");
        }


        public async Task<IActionResult> AddVendor()
        {
            var data=await service.FetchVendors();

            ViewBag.Category = new SelectList(await service.getVendorCategory(),
            "VendorCategoryId",
            "CategoryName");

            ViewBag.Company = new SelectList(await service.getCompany(),
            "CompanyId",
            "CompanyName");

            return View(data);
        }

        [HttpPost]
        
        public async Task<IActionResult> AddVendor(Vendor v)
        {
           await service.AddVendor(v);
           return new JsonResult("");

        }

        public async Task<IActionResult> DeleteVendor(int id)
        {
           await service.DelVendor(id);
            return RedirectToAction("AddVendor");
        }

        public async Task<IActionResult> GetVendorById(int id)
        {
            var vendor = await service.getVendorById(id);
            return Json(vendor);
        }

        [HttpPost]
        public async Task<IActionResult> EditVendor(Vendor v)
        {
            await service.UpdateVendor(v);
            return new JsonResult("");
        }

        public async Task<IActionResult> DeleteVendorCategory(int id)
        {
            await service.DelVendorCategory(id);
            return RedirectToAction("AddVendorCategory");
        }

        public async Task<IActionResult> GetVendorCategoryById(int id)
        {
            var vendor = await service.getVendorCategoryById(id);
            return Json(vendor);
        }

        public async Task<IActionResult> EditVendorCategory(VendorCategory v)
        {
            await service.UpdateVendorCategory(v);
            return new JsonResult("");
        }

        public async Task<IActionResult> DeleteVendorDocument(int id)
        {
            await service.DelVendorDocument(id);
            return RedirectToAction("AddDocument");
        }

    }
}

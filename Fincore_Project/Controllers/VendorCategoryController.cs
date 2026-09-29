using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fincore_Project.Controllers
{
    public class VendorCategoryController : Controller
    {
        IVendorCategoryService service;
        public VendorCategoryController(IVendorCategoryService service)
        {
            this.service = service;
        }
        public IActionResult AddVendorCategory()
        {
            return View();
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


    }
}

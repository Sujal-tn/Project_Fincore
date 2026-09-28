using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fincore_Project.Controllers
{
    public class PRController : Controller
    {
        IPRService service;
        public PRController()
        {
            this.service = service;
        }
        public async Task <IActionResult> AddPR()
        {
            ViewBag.CapexList = new SelectList(
                await service.GetCapexRequests(),
                "CapexRequestId",
                "Title");

            ViewBag.VendorList = new SelectList(
                await service.GetVendors(),
                "VendorId",
                "VendorCode");

            ViewBag.UserList = new SelectList(
                await service.GetUsers(),
                "UserId",
                "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPR(PurchaseRequisition pr)
        {

            await service.AddPR(pr);
            return new JsonResult("");
        }

    }
}

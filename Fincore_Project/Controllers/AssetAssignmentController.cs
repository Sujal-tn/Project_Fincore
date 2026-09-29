using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fincore_Project.Controllers
{
    public class AssetAssignmentController : Controller
    {
        IAssetAssignmentService aas;
        public AssetAssignmentController(IAssetAssignmentService aas)
        {
            this.aas = aas;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Assets = await aas.FetchAll();
            ViewBag.Employees = await aas.FecthAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAssignment(AssetAssignment a)
        {
            await aas.AddAssignment(a);
            return Json("Asset Assigned Successfully" );
        }

        public async Task<IActionResult> FetchAssignment()
        {
            var fa = await aas.FetchAssignment();
            return Json(fa);
        }
    }
}

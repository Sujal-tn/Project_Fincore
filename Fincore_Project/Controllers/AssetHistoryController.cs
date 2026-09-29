using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fincore_Project.Controllers
{
    public class AssetHistoryController : Controller
    {
        IAssetHistoryService ahs;
        public AssetHistoryController(IAssetHistoryService ahs)
        {
            this.ahs = ahs;
        }
        public async Task<IActionResult> Index()
        {
            var fa = await ahs.FetchAsset();
            ViewBag.assets = new SelectList(fa, "AssetId", "AssetName");

            var fu = await ahs.FetchUser();
            ViewBag.users = new SelectList(fu, "UserId", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHistory(AssetHistory h)
        {
            await ahs.AddHistory(h);
            return Json("Asset History Added Successfully");
        }

        public async Task<IActionResult> FetchAll()
        {
            var hlist = await ahs.FetchAll();
            return Json(hlist);
        }
    }
}

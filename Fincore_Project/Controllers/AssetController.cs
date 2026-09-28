using Fincore_Project.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fincore_Project.Controllers
{
    public class AssetController : Controller
    {
        IAssetService ias;
        public AssetController(IAssetService ias)
        {
            this.ias = ias;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FetchAll()
        {
            var a = await ias.FetchAll();
            return Json(a);
        }

        public async Task<IActionResult> FetchById(int id)
        {
            var ast = await ias.FetchById(id);
            return Json(ast);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddAsset(Asset a)
        //{
        //    await ias.AddAsset(a);
        //    return Json("Asset Added Successfully!!");
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateAsset(Asset a)
        //{
        //    await ias.UpdateAsset(a);
        //    return Json("Asset Updated Successfully!!");
        //}

        [HttpPost]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            await ias.DeleteAsset(id);
            return Json("Asset Deleted Successfully!!");
        }
    }
}

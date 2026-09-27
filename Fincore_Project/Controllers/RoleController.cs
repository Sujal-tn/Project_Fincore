using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fincore_Project.Controllers
{
    public class RoleController : Controller
    {
        IRoleService rs;
        public RoleController(IRoleService rs)
        {
            this.rs= rs;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(Role r)
        {
            await rs.AddRole(r);
            return Json("Role Added Successfully");
        }
    }
}

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
        public async  Task<IActionResult> Index()
        {
            var roles= await rs.GetRoles();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(Role r)
        {
            await rs.AddRole(r);
            return Json("Role Added Successfully");
        }

        public async Task<IActionResult> GetRole(int id)
        {
            var role= await rs.GetRoleById(id);
            return Json(role);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(Role r)
        {
            await rs.UpdateRole(r);
            return Json("Role Updated");
            //return RedirectToAction("Index");

        }

        public async Task<IActionResult> DelRole(int id)
        {
            await rs.DelRole(id);
            return Json("Role Deleted Successfully");
        }
    }
}

using Fincore_Project.DTO;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Fincore_Project.Controllers
{
    public class AuthController : Controller
    {
        IAuthService service;
         
        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserDto rs)
        {
            if(!ModelState.IsValid)
            {
                return View(rs);
            }

            var res = await service.ResgisterUser(rs);
            if(res == "Email Already Exists")
            {
                ModelState.AddModelError("Email", res);

                return View(rs);
            }

            return RedirectToAction("Login");

        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto log)
        {
            if(!ModelState.IsValid)
            {
                return View(log);
            }

            var user = await service.LoginUser(log);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(log);
            }

            HttpContext.Session.SetInt32("UserId", user.UserId );
            HttpContext.Session.SetString("UserName", user.FullName);
            if(user.RoleId.HasValue)
            {
                HttpContext.Session.SetInt32("RoleId", user.RoleId.Value);
                HttpContext.Session.SetString("RoleName", user.Roles.RoleName);
            }

           if(user.Roles.RoleName == "Admin" )
            {
                return RedirectToAction("AdminD", "Auth");
            }
           else
            {
                return RedirectToAction("VendorD", "Auth");
            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Auth");
        }

        public async Task<IActionResult> AdminD()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }

        public async Task<IActionResult> VendorD()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }
    }
}

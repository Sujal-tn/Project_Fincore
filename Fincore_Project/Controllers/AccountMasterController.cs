using Fincore_Project.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fincore_Project.Controllers
{
    public class AccountMasterController : Controller
    {
        IAccountMasterService service;

        public AccountMasterController(IAccountMasterService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

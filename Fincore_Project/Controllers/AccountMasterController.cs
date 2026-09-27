using Fincore_Project.Interface;
using Fincore_Project.Models;
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
     
    }
}

using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;

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

        public async Task<IActionResult> GetAccounts()
        {
            var data = await service.GetAccounts();
            return Json(data);
        }

        public async Task<IActionResult> AddAccount(AccountMaster account)
        {
            //int userId = HttpContext.Session.GetInt32("UserId");

            //if (userId == null)
            //{
            //    return Json(new { Message = "UserId not found in Session" });
            //}
            int userId = 3;

            account.CreatedBy = userId;
            account.CreatedAt = DateTime.Now;

            account.AccountCode = "ACC" + DateTime.Now.Ticks;


            await service.AddAccount(account);

            return Json(new { Message = "Account Add Successfully!!!" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await service.GetAccountById(id);
            return Json(data);
        }

        public async Task<IActionResult> Update(AccountMaster account)
        {
            //int userId = HttpContext.Session.GetInt32("UserId");
            int userId = 3; 
            account.ModifiedBy = userId;
            account.ModifiedAt = DateTime.Now;

            await service.UpdateAccount(account);


            return Json(new {message = "Account Update Successfully!!!" });
       }

        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAccount(id);
            return Json(new {message = "Account Deleted Successfully!!!" });
        }

    }
}

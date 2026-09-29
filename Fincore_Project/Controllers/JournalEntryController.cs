using Microsoft.AspNetCore.Mvc;

namespace Fincore_Project.Controllers
{
    public class JournalEntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

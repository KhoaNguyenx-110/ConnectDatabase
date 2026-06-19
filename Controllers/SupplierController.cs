using Microsoft.AspNetCore.Mvc;

namespace ConnectDatabase.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}

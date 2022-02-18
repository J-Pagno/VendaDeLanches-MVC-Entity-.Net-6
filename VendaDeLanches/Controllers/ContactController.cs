using Microsoft.AspNetCore.Mvc;

namespace VendaDeLanches.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

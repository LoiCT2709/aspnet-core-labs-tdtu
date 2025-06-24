using Microsoft.AspNetCore.Mvc;

namespace Bai1.Controllers
{
    public class SimpleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

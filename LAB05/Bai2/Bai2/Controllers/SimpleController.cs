using Microsoft.AspNetCore.Mvc;

namespace Bai2.Controllers
{
    public class SimpleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

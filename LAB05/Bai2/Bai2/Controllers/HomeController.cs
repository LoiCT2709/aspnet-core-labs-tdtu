using Bai2.Models;
using Bai2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bai2.Controllers
{
    public class HomeController : Controller
    {
       /* private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/

        private IEmployeeRepository _employeesRepository;
        
        public HomeController(IEmployeeRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public ViewResult Index()
        {
            var model = _employeesRepository.GetAllEmployees();
            return View(model);
        }
    }
}

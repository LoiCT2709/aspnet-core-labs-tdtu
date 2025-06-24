using Bai3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bai3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Student student = new Student();
            student.Country = "FR";
            return View(student);
        }
        [HttpPost]
        public IActionResult Index(Student student)
        {

            var name = student.Name;
            var country = student.Country;
            var Email = student.Email;

            return View(new Student());
        }

    }
}

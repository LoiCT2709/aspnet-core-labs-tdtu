using Microsoft.AspNetCore.Mvc;
using Cau1.Data;
using Cau1.Models;
using System.Linq;

namespace Cau1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerDBContext _context;

        public CustomerController(CustomerDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // 🔹 Kiểm tra null
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList(); // 🔹 Lấy danh sách khách hàng

            if (customers == null || !customers.Any())
            {
                ViewBag.Message = "Không có dữ liệu khách hàng."; // 🔹 Thông báo nếu rỗng
            }

            return View(customers); // 🔹 Truyền dữ liệu xuống View
        }
    }
}

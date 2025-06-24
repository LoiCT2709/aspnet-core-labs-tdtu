using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Task1.Models;

public class HomeController : Controller
{
    // Danh sách sản phẩm mẫu
    private List<Product> Products = new List<Product>
    {
        new Product { Name = "iPhone 14", Price = 15 },
        new Product { Name = "iPhone 16 Pro", Price = 26 },
        new Product { Name = "iPhone 16 Pro Max", Price = 31 },
        new Product { Name = "Samsung S25", Price = 30 },
        new Product { Name = "Samsung S25 Ultra", Price = 36 },
        new Product { Name = "iPad 15", Price = 20 },
        new Product { Name = "Sony", Price = 15 }
    };

    // GET: /Home/Search
    public IActionResult Search(string query)
    {
        // Nếu query rỗng, trả về toàn bộ sản phẩm
        var results = string.IsNullOrEmpty(query)
            ? Products
            : Products.Where(p => p.Name.Contains(query, System.StringComparison.OrdinalIgnoreCase)).ToList();

        return Json(results); // Trả về dữ liệu dưới dạng JSON
    }
    public IActionResult Index()
    {
        return View(); // Trả về view mặc định Index.cshtml
    }



}

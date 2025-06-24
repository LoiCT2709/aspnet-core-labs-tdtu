using Bai4.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bai4.Controllers
{
    public class ProductController:Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }
    }
}

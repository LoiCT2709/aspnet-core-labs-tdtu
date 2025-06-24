using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cau2.Models;
using Cau2.Extensions;
using System.Collections.Generic;
using System.Linq;
//Thêm NLog vào
using NLog;
namespace Cau2.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        //Thêm logger
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            // Lấy giỏ hàng từ session, nếu chưa có thì tạo mới danh sách giỏ hàng trống
            var cart = HttpContext.Session.Get<List<ProductItem>>("cart") ?? new List<ProductItem>();

            // Tính toán SubTotal cho từng sản phẩm trong giỏ hàng
            foreach (var item in cart)
            {
                item.SubTotal = item.Quantity * item.Product.Price;
            }

            // Tính tổng số tiền của giỏ hàng
            ViewBag.Total = cart.Sum(s => s.SubTotal);

            // Trả về view với danh sách giỏ hàng đã tính toán SubTotal
            return View(cart);
        }


        public IActionResult Buy(string sku)
        {
            var product = _productService.GetProduct(sku);
            var cart = HttpContext.Session.Get<List<ProductItem>>("cart") ?? new List<ProductItem>();

            if (product != null)
            {
                var item = cart.FirstOrDefault(w => w.Product?.Sku == sku);
                if (item != null)
                {
                    item.Quantity++;
                }
                else
                {
                    cart.Add(new ProductItem { Product = product, Quantity = 1 });
                }
                HttpContext.Session.Set("cart", cart);
                //Thêm logger info:
                logger.Info($"Them san pham moi vao gio hang: [SKU: {product.Sku}, Ten: {product.Name}, So luong: 1]");
            }
            else
            {
                logger.Error($"Khong tim thay san pham voi SKU: {sku}");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Add(string sku)
        {
            var product = _productService.GetProduct(sku);
            var cart = HttpContext.Session.Get<List<ProductItem>>("cart");
            if (cart != null && product != null)
            {
                int index = cart.FindIndex(w => w.Product?.Sku == sku);
                if (index != -1)
                {
                    cart[index].Quantity++;
                    HttpContext.Session.Set("cart", cart);
                    logger.Info($"Tang so luong san pham: [SKU: {product.Sku}, Ten: {product.Name}, So luong moi: {cart[index].Quantity}]");
                }
            }
            else
            {
                logger.Error($"Cart null hoac khong tim thay san pham. SKU: {sku}");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Minus(string sku)
        {
            var product = _productService.GetProduct(sku);
            var cart = HttpContext.Session.Get<List<ProductItem>>("cart");
            if (cart != null && product != null)
            {
                int index = cart.FindIndex(w => w.Product?.Sku == sku);
                if (index != -1)
                {
                    if (cart[index].Quantity == 1)
                    {
                        cart.RemoveAt(index);
                        logger.Warn($"Xoa san pham cuoi cung: [SKU: {product.Sku}, Ten: {product.Name}]");

                    }
                    else
                    {
                        cart[index].Quantity--;
                        logger.Info($"Giam so luong san pham: [SKU: {product.Sku}, Ten: {product.Name}, Con lai: {cart[index].Quantity}]");
                    }
                    HttpContext.Session.Set("cart", cart);
                }
            }
            else
            {
                logger.Error($"Cart null hoac khong tim thay san pham. SKU: {sku}");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string sku)
        {
            var product = _productService.GetProduct(sku);
            var cart = HttpContext.Session.Get<List<ProductItem>>("cart");
            if (cart != null && product != null)
            {
                int index = cart.FindIndex(w => w.Product?.Sku == sku);
                if (index != -1)
                {
                    cart.RemoveAt(index);
                    HttpContext.Session.Set("cart", cart);
                    logger.Info($"Xoa san pham khoi gio: [SKU: {product.Sku}, Ten: {product.Name}]");
                }
            }
            else
            {
                logger.Error($"Cart null hoac khong tim thay san pham. SKU: {sku}");
            }
            return RedirectToAction("Index");
        }

    }
}
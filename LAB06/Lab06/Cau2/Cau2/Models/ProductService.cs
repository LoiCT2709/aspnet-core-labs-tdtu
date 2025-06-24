namespace Cau2.Models
{
    public class ProductService : IProductService 
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Sku = "IP12", Name = "iPhone 12", Price = 100000 },
            new Product { Sku = "IP12P", Name = "iPhone 12 Pro", Price = 120000 },
            new Product { Sku = "IP10", Name = "iPhone 10", Price = 80000 },
            new Product { Sku = "IP11", Name = "iPhone 11", Price = 90000 }
        };

        public Product GetProduct(string sku)
        {
            return _products.FirstOrDefault(p => p.Sku == sku);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }
    }
}
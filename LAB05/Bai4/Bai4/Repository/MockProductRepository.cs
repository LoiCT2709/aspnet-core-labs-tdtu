using Bai4.Models;
using System.Linq;
using System.Linq;           // Để sử dụng LINQ, ví dụ như FirstOrDefault

using System.Collections.Generic; // Để sử dụng List<T>

namespace Bai4.Repository
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _productList;

        public MockProductRepository()
        {
            _productList = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Category = "Category A", Price = 10.99m },
                new Product { Id = 2, Name = "Product 2", Category = "Category B", Price = 20.99m },
                new Product { Id = 3, Name = "Product 3", Category = "Category C", Price = 30.99m }
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productList;
        }

        public Product GetProduct(int id)
        {
            return _productList.FirstOrDefault(p => p.Id == id);
        }
    }
}

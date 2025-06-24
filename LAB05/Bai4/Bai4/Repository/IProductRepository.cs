using Bai4.Models;
namespace Bai4.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
    }
}

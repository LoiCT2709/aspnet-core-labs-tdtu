namespace Cau2.Models
{
    public interface IProductService
    {
        Product GetProduct(string sku);
        List<Product> GetAllProducts();
    }
}

namespace Cau2.Models
{
    public class ProductItem
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; } // Thêm thuộc tính SubTotal
    }
}

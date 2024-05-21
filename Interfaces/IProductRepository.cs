using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductId(int id);
        Product GetProductName(string name);
        Product GetProductDescription(string description);
        Product GetProductPrice(int price);
        Product GetProductYear(int year);
        bool ProductExists(int productId);
    }
}

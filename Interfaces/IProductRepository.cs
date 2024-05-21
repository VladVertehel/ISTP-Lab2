using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
    }
}

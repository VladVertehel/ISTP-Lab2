using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class ProductRepository : IProductRepository
    {   
        private readonly DataContext _context;
        public ProductRepository(DataContext context) 
        {
            _context = context;
        }
        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p=>p.Id).ToList();
        }
    }
}

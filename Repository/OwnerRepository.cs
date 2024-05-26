using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        private readonly IProductRepository _productRepository;

        public OwnerRepository(DataContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            var productsOfOwner = GetProductByOwner(owner.Id).ToList();
            _productRepository.DeleteProducts(productsOfOwner);
            _context.Remove(owner);
            return Save();
        }

        public bool DeleteOwners(List<Owner> owners)
        {
            for (int i = 0; i < owners.Count(); i++)
                DeleteOwner(owners[i]);

            return Save();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAProduct(int productId)
        {
            return _context.ProductOwners.Where(p => p.ProductId == productId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Product> GetProductByOwner(int ownerId)
        {
            return _context.ProductOwners.Where(p => p.Owner.Id == ownerId).Select(p => p.Product).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }
    }
}

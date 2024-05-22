using ReviewApp.Interfaces;
using ReviewApp.Models;
using AutoMapper;
using ReviewApp.Data;

namespace ReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
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
    }
}

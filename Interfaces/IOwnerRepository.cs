using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAProduct(int productId);
        ICollection<Product> GetProductByOwner(int ownerId);
        bool OwnerExists(int ownerId);
        bool CreateOwner(Owner owner);
        bool Save();
    }
}

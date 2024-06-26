﻿using ReviewApp.Models;

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
        bool UpdateOwner(Owner owner);
        bool DeleteOwner(Owner owner);
        bool DeleteOwners(List<Owner> owners);
        bool Save();
    }
}

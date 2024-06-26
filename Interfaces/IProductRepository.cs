﻿using ReviewApp.Models;

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
        bool CreateProduct(int ownerId, int categoryId, Product product);
        bool UpdateProduct(int ownerId, int categoryId, Product product);
        bool DeleteProduct(Product product);
        bool DeleteProducts(List<Product> products);
        bool Save();
    }
}

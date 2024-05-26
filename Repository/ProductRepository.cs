﻿using ReviewApp.Data;
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

        public bool CreateProduct(int ownerId, int categoryId, Product product)
        {
            var productOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();
            var productOwner = new ProductOwner()
            {
                Owner = productOwnerEntity,
                Product = product,
            };
            _context.Add(productOwner);
            var productCategory = new ProductCategory()
            {
                Category = category,
                Product = product,
            };
            _context.Add(productCategory);
            _context.Add(product);
            return Save();
        }

        public Product GetProductDescription(string description)
        {
            return _context.Products.Where(p => p.Description == description).FirstOrDefault();

        }

        public Product GetProductId(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product GetProductName(string name)
        {
            return _context.Products.Where(p => p.Name == name).FirstOrDefault();
        }

        public Product GetProductPrice(int price)
        {
            return _context.Products.Where(p => p.Price == price).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Id).ToList();
        }

        public Product GetProductYear(int year)
        {
            return _context.Products.Where(p => p.Year == year).FirstOrDefault();
        }

        public bool ProductExists(int productId)
        {
            return _context.Products.Any(p => p.Id ==  productId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

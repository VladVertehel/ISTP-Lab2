using Microsoft.EntityFrameworkCore;
using ReviewApp.Models;

namespace ReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOwner> ProductOwners { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<ProductOwner>()
                .HasKey(po => new { po.ProductId, po.OwnerId });
            modelBuilder.Entity<ProductOwner>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductOwners)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductOwner>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.ProductOwners)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}

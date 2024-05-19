using ReviewApp.Data;
using ReviewApp.Models;

namespace ReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.ProductOwners.Any())
            {
                var ProductOwners = new List<ProductOwner>()
                {
                    new ProductOwner()
                    {
                        Product = new Product()
                        {
                            Name = "Jeep",
                            Description = "it drives",
                            Price = 10000,
                            Year = 2003,
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { Name = "Car"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Jeep",Text = "Nice jeep bro",
                                Reviewer = new Reviewer(){ Name = "Oleg", Contacts = "oleg@mail.com" } },
                                new Review { Title="Jeep",Text = "its ok",
                                Reviewer = new Reviewer(){ Name = "Rob", Contacts = "rob@mail.com" } },
                                new Review { Title="Jeep",Text = "lol",
                                Reviewer = new Reviewer(){ Name = "Max", Contacts = "max@mail.com" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Jack",
                            Contacts = "jack@mail.com",
                            Country = new Country()
                            {
                                Name = "USA"
                            }
                        }
                    },
                    new ProductOwner()
                    {
                        Product = new Product()
                        {
                            Name = "Apple",
                            Description = "green",
                            Price = 2,
                            Year = 2024,
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { Name = "Fruit"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Apple",Text = "sweet",
                                Reviewer = new Reviewer(){ Name = "Vasya", Contacts = "vasya@mail.com" } },
                                new Review { Title="Apple",Text = "Its best for an apple pie!",
                                Reviewer = new Reviewer(){ Name = "Maryna", Contacts = "maryna@mail.com" } },
                                new Review { Title="Apple",Text = "Very sour, not recommended",
                                Reviewer = new Reviewer(){ Name = "Eva", Contacts = "eva@mail.com" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Fruit Farm #1",
                            Contacts = "fruitfarm1@mail.com",
                            Country = new Country()
                            {
                                Name = "Ukraine"
                            }
                        }
                    },
                    new ProductOwner()
                    {
                        Product = new Product()
                        {
                            Name = "Pencil",
                            Description = "writes or draws whatever u want!",
                            Price = 5,
                            Year = 2015,
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { Name = "Stationery"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Pencil",Text = "its broken",
                                Reviewer = new Reviewer(){ Name = "Maria", Contacts = "maria@mail.com" } },
                                new Review { Title="Pencil",Text = "love it",
                                Reviewer = new Reviewer(){ Name = "Bogdan", Contacts = "bogdan@mail.com" } },
                                new Review { Title="Pencil",Text = "just ok",
                                Reviewer = new Reviewer(){ Name = "Vlad", Contacts = "vlad@mail.com" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Stationery store",
                            Contacts = "stst@mail.com",
                            Country = new Country()
                            {
                                Name = "Germany"
                            }
                        }
                    },
                };
                dataContext.ProductOwners.AddRange(ProductOwners);
                dataContext.SaveChanges();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace SMMS.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Categories.Any() || context.Products.Any())
                {
                    context.Categories.RemoveRange(context.Categories);
                    context.Products.RemoveRange(context.Products);
                    context.SaveChanges();
                }

                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Beverage",
                        Description = "Beverages like tea, coffee, juice, etc."
                    },
                    new Category
                    {
                        Name = "Bakery",
                        Description = "Bakery products such as bread, pastries, etc."
                    },
                    new Category
                    {
                        Name = "Meat",
                        Description = "Various kinds of meat products."
                    }
                );

                context.SaveChanges();


                var beverageCategory = context.Categories.FirstOrDefault(c => c.Name == "Beverage");
                var bakeryCategory = context.Categories.FirstOrDefault(c => c.Name == "Bakery");
                var meatCategory = context.Categories.FirstOrDefault(c => c.Name == "Meat");


                context.Products.AddRange(
                    new Product
                    {
                        Name = "Tea",
                        Price = 1.50m,
                        CategoryId = beverageCategory!.CategoryId
                    },
                    new Product
                    {
                        Name = "Coffee",
                        Price = 3.00m,
                        CategoryId = beverageCategory!.CategoryId
                    },
                    new Product
                    {
                        Name = "Bread",
                        Price = 2.50m,
                        CategoryId = bakeryCategory!.CategoryId
                    },
                    new Product
                    {
                        Name = "Pastry",
                        Price = 5.00m,
                        CategoryId = bakeryCategory!.CategoryId
                    },
                    new Product
                    {
                        Name = "Chicken",
                        Price = 10.00m,
                        CategoryId = meatCategory!.CategoryId
                    },
                    new Product
                    {
                        Name = "Beef",
                        Price = 15.00m,
                        CategoryId = meatCategory!.CategoryId
                    }
                );

                context.SaveChanges();
            }
        }

    }
}

using System.Linq;


namespace Seminar11
{
    public class ProductSeeder
    {
        public static void Initialize(ProductDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                new Product
                {
                    Name = "tv",
                    Category = "electrocasnice",
                    Description = "mare",
                    Price = 23.00


                },
                new Product
                {
                    Name = "frigider",
                    Category = "electrocasnice",
                    Description = "mare",
                    Price = 25.00


                }
            );
            context.SaveChanges();
        }
    }
}


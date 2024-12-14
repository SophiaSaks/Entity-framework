using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var product = new TestProduct()
                {
                    Id = new Guid("7948c941-9b36-47cd-9b22-73ebf0f5d922"),
                    Name = "Shoes",
                    Description = "Fancy pair of shoes",
                    Price = 10.2m
                };
                context.Products.Add(product);
                context.SaveChanges();

                var p = context.Products.FirstOrDefault();
            }
        }

        public class TestProduct
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Decimal Price { get; set; }
        }

        public class MyDbContext : DbContext
        {
            public DbSet<TestProduct> Products { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {

                optionsBuilder.UseInMemoryDatabase("MyTestDb");    
            }
        }
    }
}


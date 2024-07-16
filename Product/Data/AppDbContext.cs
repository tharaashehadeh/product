/*using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
           new Products { Id = 1, Name = "Laptop", Description = "This Is Product One" },
           new Products { Id = 2, Name = "DeskTop", Description = "This Is Product Two" },
           new Products { Id = 3, Name = "Printer", Description = "This Is Product Three" },
           new Products { Id = 4, Name = "HeadPhone", Description = "This Is Product Four" }

               );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Products> Productss { set; get; }
    }
}
*/
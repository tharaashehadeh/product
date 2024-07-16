using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepositories : GenericRepository<Products>,IProductRepositories
    {
        private readonly AplicationDbContext dbContext;

        public ProductRepositories(AplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Products> CreateProductAsync(Products product)
        {
           dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Products>> GetAllProductsByCategoryId(int Cat_Id)
        {///Eager Loading 
            /* var products = (IEnumerable<Products>)await dbContext.Products.Include(x => x.Category)
                  .Where(c => c.Category_Id == Cat_Id)
                  .ToListAsync();
             return products;*/


            //Explicet loading 
            /* var products = await dbContext.Products
                            .Where(c => c.Category_Id == Cat_Id)
                            .ToListAsync();
             foreach(var product in products)
             {
              await   dbContext.Entry(product).Reference(r => r.Category).LoadAsync();
             }
             return products;*/
            ////lazy loading 
            var products = await dbContext.Products
                          .Where(c => c.Category_Id == Cat_Id)
                            .ToListAsync();
            return products;
        }

       
    }
}

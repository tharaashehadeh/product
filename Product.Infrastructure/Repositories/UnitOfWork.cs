using Product.Core.IRepositories;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AplicationDbContext dbContext;

        public UnitOfWork(AplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            productRepositories = new ProductRepositories(dbContext);
        }
     public   IProductRepositories productRepositories { get ; set ; }
      public  ICategoryRepositoies categoryRepositoies { get; set; }

        public async Task <int> save()
        
           => await dbContext.SaveChangesAsync();
       
    }
}

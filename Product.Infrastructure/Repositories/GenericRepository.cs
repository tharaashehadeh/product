using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepositoies<T> where T : class

    {
        private readonly AplicationDbContext dbContext;

        public GenericRepository(AplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       public async Task Create(T model)
        {
         await   dbContext.Set<T>().AddAsync(model);
        }

       public void Delete(int id)
        {
            dbContext.Remove(id);
        }

       public async Task<IEnumerable<T>> GetAll(int page_size=2,int page_number=1,string? IncludeProparity=null)
        {
            /* if(typeof(T)==typeof(Products))
             {
                 var model = await dbContext.Products.Include(x => x.Category).ToListAsync();
                 return (IEnumerable<T>)model;
             }*/

            /* if(typeof(T)== typeof(Categories))
             {
                 var model = await dbContext.Categories.Include(x => x.Category).ToListAsync();
                 return (IEnumerable<T>)model;
             }*/
           IQueryable<T> query = dbContext.Set<T>();
            if(IncludeProparity!=null)
            {
                foreach (var proparity in IncludeProparity.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProparity);
                }
            }
            if (page_size>0)
            {
                if (page_size > 10)
                {
                    page_size = 10;
                }
                query = query.Skip(page_size*(page_number-1)).Take(page_size);
            }

            // return await dbContext.Set<T>().ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

       public void Update(T model)
        {
            dbContext.Set<T>().Update(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.IRepositories
{
    public interface IUnitOfWork<T> where T:class
    {
        public IProductRepositories productRepositories { get; set; }
        public ICategoryRepositoies categoryRepositoies { get; set; }

        public Task< int> save();

    }
}

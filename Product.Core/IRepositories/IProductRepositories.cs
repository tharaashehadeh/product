using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.IRepositories
{
    public interface IProductRepositories:IGenericRepositoies<Products>
    {
      public Task <IEnumerable<Products>> GetAllProductsByCategoryId(int Cat_Id);
    }
}

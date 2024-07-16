using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.IRepositories
{
    public interface IGenericRepositoies<T> where T:class
    {
        public Task< IEnumerable<T>>GetAll(int page_size = 2 ,int page_number=3,string? IncludeProparity=null);
        public Task <T>GetById(int id);
        public Task Create(T model);
        public void Update(T model);
        public void Delete(int id);
    }
}

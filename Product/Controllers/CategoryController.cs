using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;
        private readonly IUnitOfWork<Categories> unitOfWork;

        // private readonly IGenericRepositoies<Categories> genericRepositoies;

        public CategoryController(AplicationDbContext dbContext,IUnitOfWork<Categories>unitOfWork)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
            //this.genericRepositoies = genericRepositoies;
        }
    }
}

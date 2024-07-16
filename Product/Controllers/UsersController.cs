using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Infrastructure.Data;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;

        public UsersController(AplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<List<Orders>> GetUserId(int userId)
        {
            return await dbContext.Orders
                .Include(o => o.Items) // Eager load order items
                .Where(o => o.LocalUserId == userId)
                .ToListAsync();
        }
       
       
    }
}

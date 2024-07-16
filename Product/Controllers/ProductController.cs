/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Product.Data;
using Product.Models;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Products> products = new List<Products> {
            new Products {Id=1,Name="Thara'a",Description="This Is Product One"},
            new Products {Id=2,Name="Batol",Description="This Is Product Two"},
            new Products {Id=3,Name="Ahmad",Description="This Is Product Three"},
        };
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var product = products.First(product => product.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]

        public IActionResult Add(Products request)
        {
            if (request is null)
            {
                return BadRequest();
            }
            var product = new Products
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };
            products.Add(product);//list
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Products request)
        {
            var currentProduct = products.FirstOrDefault(product => product.Id == id);
            if (currentProduct is null)

                return NotFound();
            currentProduct.Name = request.Name;
            currentProduct.Description = request.Description;
            return Ok(currentProduct);



        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if (product is null)

                return NotFound();
            products.Remove(product);
            return Ok();
        }*/
      /*  private readonly AppDbContext dbContext;
        public ProductController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = dbContext.Productss;
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult GetByID(int id)
        {
            var products = dbContext.Productss.Find(id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }
        [HttpPost]
        public ActionResult CreateProduct(Products model)
        {
            dbContext.Productss.Add(model);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetByID), new { id = model.Id }, model);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Products model)
        {
            var product = dbContext.Productss.Find(id);
            if (product == null)
                return NotFound();
            product.Name = model.Name;
            product.Description = model.Description;
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = dbContext.Productss.Find(id);
            dbContext.Productss.Remove(product);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
*/
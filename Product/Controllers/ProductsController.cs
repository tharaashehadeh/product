using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.Entities.DTO;
using Product.Core.IRepositories;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repositories;
using Product.Models;
using Products = Product.Core.Entities.Products;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       //private readonly AplicationDbContext dbContext;
        private readonly IUnitOfWork<Products> unitOfWork;
        private readonly IMapper mapper;
        public ApiResponse response;

        //private readonly IGenericRepositoies<Products> genericRepositoies;

         private readonly ProductRepositories productRepositories;

        public ProductsController(/*AplicationDbContext dbContex*/ProductRepositories productRepositories,IUnitOfWork<Products>unitOfWork,IMapper mapper)
        {
          // this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            //  this.genericRepositoies = genericRepositoies;
            this.productRepositories = productRepositories;
            response = new ApiResponse();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllProducts(int pageSize=2,int pageNumber=1)
        {
            // var model = dbContext.Products;
            // var model=  productRepositories.GetAll();
            var model = await unitOfWork.productRepositories.GetAll(page_size: pageSize,page_number: pageNumber,IncludeProparity:"Category");
            var check = model.Any();
            if (check)
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = check;
                var mappedProducts = mapper.Map<IEnumerable<Products>, IEnumerable<ProductDTO>>(model);
                response.Result = mappedProducts;
                return response;

            }
            else
            {
                response.ErrorMessages = "not products found";
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = false;
                return response;

            }
           
        }





        [HttpGet("{id}")]
        public async Task<ActionResult>GetById(int id )
        {
            var product = await productRepositories.GetById(id);
            //var model = dbContext.Products.Find(id);
          //  var model = await unitOfWork.productRepositories.GetById(id);

            return Ok(product);
        }
        [HttpPost]
       // public async Task  <ActionResult<ApiResponse>> CreateProduct(Products model)
       /* {
            // dbContext.Products.Add(model);
           await unitOfWork.productRepositories.Create(model);
           // unitOfWork.productRepositories.Update(model);
            unitOfWork.save();
            //dbContext.SaveChanges(); 
            return Ok(model);
        }*/
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDTO ProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = mapper.Map<Products>(ProductDto);
            var createdProduct = await productRepositories.CreateProductAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut]
        public async Task <ActionResult<ApiResponse>> UpdateProduct(Products model)
        {
            // dbContext.Products.Update(model);
            unitOfWork.productRepositories.Update(model);
           await unitOfWork.save();
            return Ok(model);
        }
        [HttpDelete]
        public async Task <ActionResult<ApiResponse>> DeleteProduct(int id)
        {
            // var model = dbContext.Products.Find(id);
            //dbContext.Products.Remove(model);
            unitOfWork.productRepositories.Delete(id);
          await unitOfWork.save();
            return Ok();
        }
        [HttpGet("Product/{cat_id}")]
        public async Task<ActionResult<ApiResponse>> GetProductByCatId(int cat_id)
        {
            var products =await unitOfWork.productRepositories.GetAllProductsByCategoryId(cat_id);
            var mappingProducts = mapper.Map<IEnumerable<Products>, IEnumerable<ProductDTO>>(products);
            return  Ok (mappingProducts);
        }

    }
}

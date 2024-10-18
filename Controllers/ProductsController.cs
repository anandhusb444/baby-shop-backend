using baby_shop_backend.DTO.CategoryDTO;
using baby_shop_backend.DTO.ProductDTO;
using baby_shop_backend.Models;
using baby_shop_backend.Respones;
using baby_shop_backend.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace baby_shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IproductServices _productRepo;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IproductServices product, ILogger<ProductsController> log)
        {
            _productRepo = product;
            _logger = log;
        }

        [HttpGet ("All Products")]
        public async Task<IActionResult> GelAll()
        {
            try
            {
                var products = await _productRepo.GetAllProducts();
                return Ok(new GenericApiRespones<object>(200, "Sucessfully Fetched all the products", products));
                
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500, ex.Message);
                    
            }
        }

        [HttpGet ("ProductById{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var product = await _productRepo.GetProductsById(Id);
                return Ok(new GenericApiRespones<object>(200, "Sucessfully fetched by id", product));

            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal Server error", null, ex.Message);
                return StatusCode(500, respones);
            }
        }

        [HttpPost("productByCategory")]
        public async Task<IActionResult> GetByCategory(CategoryDTO category)
        {
            try
            {
                var product = await _productRepo.GetProductByCat(category);
                return Ok(new GenericApiRespones<object>(200, "Ok", product));
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "internal server error", null, ex.Message);
                return StatusCode(500,respones);
            }
        }

        [HttpGet("Search/{Name}")]
        public async Task<IActionResult> GetByName(string Name)
        {
            try
            {
                var product = await _productRepo.Search(Name);
                return Ok(new GenericApiRespones<object>(200, "Ok", product));
                
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost ("AddProducts")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProducts([FromForm]AddProductDTO product,IFormFile img)
        {
            try
            {
                var result = await _productRepo.AddProduct(product, img);
                if(result)
                {
                    return Ok(new GenericApiRespones<object>(200, "Product as been added", result));
                }
                else
                {
                    return BadRequest(new GenericApiRespones<object>(400, "product already Been exist", result));
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in addproduct controller:" + ex.InnerException?.Message ?? ex.Message);
                var respones = new GenericApiRespones<object>(500, "Internal Server erro", null, ex.Message);
                return StatusCode(500, respones);
            }
        }


        [HttpPut("UpdateProduct{Id}")]
        [Authorize (Roles = "Admin")]

        public async Task<IActionResult> Update(int Id, [FromForm] AddProductDTO product,IFormFile image)
        {
            try
            {
                var prod = await _productRepo.UpdateProduct(Id, product,image);
                if(prod)
                {
                    return Ok(new GenericApiRespones<object>(200, "Update Successfuly", prod));
                  
                }
                else
                {
                    return BadRequest(new GenericApiRespones<object>(400, "product not found", null));
                }
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal Server error",null, ex.Message);
                return StatusCode(500, respones);
            }
        }

        [HttpDelete("Delete {Id}")]
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var res = await _productRepo.DeleteProduct(Id);
                if(res != null)
                {
                    return Ok(new GenericApiRespones<object>(200, "Successfully deleted", res));
                    
                }
                else
                {
                    return BadRequest(new GenericApiRespones<object>(400, "No product found", res));
                    
                }
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500, respones);
            }
        }


    }


}

using baby_shop_backend.DTO.CategoryDTO;
using baby_shop_backend.DTO.ProductDTO;
using baby_shop_backend.Models;
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

        public ProductsController(IproductServices product)
        {
            _productRepo = product;
        }

        [HttpGet ("All Products")]
        public async Task<IActionResult> GelAll()
        {
            try
            {
                var products = await _productRepo.GetAllProducts();
                return Ok(products);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
                    
            }
        }

        [HttpGet ("ProductById{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var product = await _productRepo.GetProductsById(Id);
                return Ok(product);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("productByCategory")]
        public async Task<IActionResult> GetByCategory(CategoryDTO category)
        {
            try
            {
                var product = await _productRepo.GetProductByCat(category);
                return Ok(product);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Search/{Name}")]
        public async Task<IActionResult> GetByName(string Name)
        {
            try
            {
                var product = await _productRepo.Search(Name);
                return Ok(product);
            }
            catch(Exception ex)
            {
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
                    return Ok("Producted Added sucessfully");

                }
                else
                {
                    return BadRequest("Producte already exist");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("UpdateProduct{Id}")]
        [Authorize (Roles = "Admin")]

        public async Task<IActionResult> Update([FromForm]int Id, AddProductDTO product, IFormFile image)
        {
            try
            {
                var prod = await _productRepo.UpdateProduct(Id, product,image);
                if(prod != null)
                {
                    return Ok("Updated SuccessFuly");
                }
                else
                {
                    return BadRequest("product Not Found");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
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
                    return Ok("Successfully deleted");
                }
                else
                {
                    return BadRequest("No product found");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }


}

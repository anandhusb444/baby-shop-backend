using baby_shop_backend.Services.CartServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace baby_shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IcartServies _cartRepo;
        //private 
        public CartController(IcartServies servies)
        {
            _cartRepo = servies;
        }

        [HttpGet("Cart")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split();
                var jwt = token[1];

                var cart = await _cartRepo.GetAllProducts(jwt);
                return Ok(cart);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddtoCart")]
        [Authorize]
        public async Task<IActionResult> AddCart(int productId)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split();
                var jwt = token[1];

                var result = await _cartRepo.AddToCart(jwt, productId);
                return Ok(result);
            }
            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

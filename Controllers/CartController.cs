using baby_shop_backend.Respones;
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
                if(cart != null)
                {
                    return Ok(new GenericApiRespones<object>(200, "succefuly Get the cart", cart));

                }
                else
                {
                    return BadRequest(new GenericApiRespones<object>(400, "Cart is Empty", null));
                }

            }
            catch(Exception ex)
            {
                return BadRequest(new GenericApiRespones<object>(400, "Internal server error occured", null, ex.Message));
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
                if (result == "CannotFindUser")
                {
                    return NotFound(new GenericApiRespones<object>(404, "can't find user", result));

                }
                else if(result == "ProductNotFound")
                {
                    return BadRequest(new GenericApiRespones<object>(400, "can't find produc", null));
                }
                else if(result == "OutOfStock")
                {
                    return BadRequest(new GenericApiRespones<object>(400, "Product is out of stock", result));
                }
                else if(result == "ExitInTheCart")
                {
                    return BadRequest(new GenericApiRespones<object>(400, "ExitInTheCart", null));
                }
                else
                {
                    return Ok(new GenericApiRespones<object>(200, "Added to Cart", result));

                }
            }
            catch(Exception ex)
            {
                return BadRequest(new GenericApiRespones<object>(400, "Internal server error occuerd", null, ex.Message));
            }
        }

        [HttpDelete("RemoveFromCart")]
        [Authorize]
        public async Task<IActionResult> Delete(int ProductId)
        {
            
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split();
                var jwt = token[1];

                var result = await _cartRepo.RemoveCart(jwt, ProductId);
                if(result == false)
                {
                    return BadRequest(new GenericApiRespones<object>(400, "Item Not found", result));
                }
                else
                {
                    return Ok(new GenericApiRespones<object>(200, "Removed from the cart", result));

                }

        }

        [HttpPut("increaseQty")]
        [Authorize]

        public async Task<IActionResult> Increase(int ProductId)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split();
            var jwt = token[1];

            var result = await _cartRepo.IncreaseQty(jwt, ProductId);

            if(result)
            {
                return Ok(new GenericApiRespones<object>(200, "QtyIncrease", result));
                //return Ok("increaseQty");

            }
            else
            {
                return BadRequest(new GenericApiRespones<object>(400, "item Not found", result));

            }
        }

        [HttpPut("DecreaseQty")]
        [Authorize]

        public async Task<IActionResult> DecreaseQty(int productId)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split();
            var jwt = token[1];

            var result = await _cartRepo.DecreaseQty(jwt, productId);
            
            if(result)
            {
                return Ok(new GenericApiRespones<object>(200,"QtyDecreased",result));
            }
            else
            {
                return BadRequest(new GenericApiRespones<object>(400, "items not Found", null));
            }
        }

    }
}

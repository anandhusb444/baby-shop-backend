using baby_shop_backend.DTO.OrderDTO;
using baby_shop_backend.Services.OrderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace baby_shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IorderServices _ordetRepo;

        public OrderController(IorderServices services)
        {
            _ordetRepo = services;
        }

        [HttpPost("OrderPlaced")]
        [Authorize]
        public async Task<IActionResult> OrderCreate(OrderDTO orderdto)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split();
                var jwt = token[1];

                var result = await _ordetRepo.OrderCreated(jwt, orderdto);
                if (result)
                {
                    return Ok("Order Placed");
                }
                else
                {
                    return Ok("No such Items in the cart");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        [HttpGet("GetOrder")]
        [Authorize]
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split();
                var jwt = token[1];

                var details = await _ordetRepo.GetOrders(jwt);

                return Ok(details);


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}

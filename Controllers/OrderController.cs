using baby_shop_backend.DTO.OrderDTO;
using baby_shop_backend.Respones;
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
                    return Ok(new GenericApiRespones<object>(200, "Order Placed", result));

                }
                else
                {
                    return BadRequest(new GenericApiRespones<object>(400, "No such Items in the Cart",result));
                }
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500, respones);
                
            }
            
        }

        [HttpPost("Payment")]
        [Authorize]
        public IActionResult Payment(PaymentDTO razorpay)
        {
            try
            {
                if(razorpay == null)
                {
                    return BadRequest(new GenericApiRespones<object>(400, "Razorpay not be null here", null));
                }
                var con = _ordetRepo.Payment(razorpay);
                return Ok(new GenericApiRespones<object>(200, "Ok", con));
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
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

                return Ok(new GenericApiRespones<object>(200, "Ok", details));
            }
            catch(Exception ex)
            {
                var response = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                //Console.WriteLine(ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("UserOrder")]
        [Authorize (Roles = "Admin")]

        public async Task<IActionResult> GetOrderAdmin(int Id)
        {
            try
            {
                var result = await _ordetRepo.GetOdersAdmin(Id);
                if (result == null)
                {
                    //Console.WriteLine("No user Found");
                    return NotFound( new GenericApiRespones<object>(400, "No order found for this users",result));
                }

                return Ok(new GenericApiRespones<object>(200,"Ok",result));

            }
            catch(KeyNotFoundException ex)
            {
              
                return NotFound(new GenericApiRespones<object>(400,"internal server error",null,ex.Message));

            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal Server error", null, ex.Message);
                return StatusCode(500,respones);
            }
        }

        [HttpGet("Total Revenue")]
        [Authorize (Roles = "Admin")]

        public async Task<IActionResult> GetRevenue()
        {
            try
            {
                var result = await _ordetRepo.TotalRevenue();
                return Ok(new GenericApiRespones<object>(200, "Ok", result));
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500, respones);   
            }
        }

        [HttpGet("Sales")]
        [Authorize (Roles = "Admin")]

        public async Task<IActionResult> GetSales()
        {
            try
            {
                var result = await _ordetRepo.TotalPurchase();
                return Ok(new GenericApiRespones<object>(200, "Ok", result));
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500, respones);
            }
        }
    }
}

using baby_shop_backend.Respones;
using baby_shop_backend.Services.WhisListServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace baby_shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhishListController : ControllerBase
    {
        private readonly IwhishList _iwhishListRepo;

        public WhishListController(IwhishList wishList)
        {
            _iwhishListRepo = wishList;
        }

        [HttpPost ("AddToWhishList")]
        [Authorize]

        public async Task<IActionResult> GetWhisList(int productId)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split();
                var jwt = token[1];
                var result = await _iwhishListRepo.AddToWhishList(jwt, productId);
                if (!result)
                {
                    return BadRequest(new GenericApiRespones<object>(400, "Item already in the WhishList", null));
                }
                return Ok(new GenericApiRespones<object>(200,"Ok",result));
            }
            catch(Exception ex)
            {
                var response = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500,response);
            }
        }

        [HttpDelete("RemoveFromWhishList")]
        public async Task<IActionResult> DeleteWhislist(int productId)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                var splitToken = token.Split(' ');
                var jwt = splitToken[1];

                var result = await _iwhishListRepo.RemoveFromWhisList(jwt, productId);
                return Ok(new GenericApiRespones<object>(200,"Ok", result));

            }
            catch(Exception ex)
            {
                Console.WriteLine("There is an error");
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetWhishList")]
        [Authorize]

        public async Task<IActionResult> GetWhisList()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split();
            var jwt = token[1];

            var result = await _iwhishListRepo.GetWhisList(jwt);

            if(result == null)
            {
                return BadRequest(new GenericApiRespones<object>(400, "some error on the WhislistGet", null));
            }
            return Ok(new GenericApiRespones<object>(200,"Ok", result));

        }
    }
}

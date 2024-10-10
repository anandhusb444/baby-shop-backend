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
                    return BadRequest("Item already in the WhishList");
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
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
                return Ok(result);

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
                return BadRequest("some error on the WhislistGet");
            }
            return Ok(result);

        }
    }
}

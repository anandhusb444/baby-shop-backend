using baby_shop_backend.Services.userServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace baby_shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserServies _user;
        private readonly IConfiguration _configer;
        private ILogger _logger;

        public UserController(IuserServies userservise, IConfiguration config, ILogger loger)
        {
            _user = userservise;
            _configer = config;
            _logger = loger;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]

        public async Task<IActionResult> GetAllUser()
        {
            _logger.LogInformation("Fetching All User");
            try
            {

                var user = _user.GetAllUsers();
                if(user == null)
                {
                    return NotFound("User Not Found");
                }
                else
                {
                    return Ok(user);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"There is a error in the GetAllUsers function : {ex.Message}");
                return BadRequest();

            }

        }

        [Authorize (Roles = "Admin")]
        [HttpGet("{Id}")]

        public async Task<IActionResult> GetUserId(int Id)
        {
            try
            {
                var user = await _user.GetUserById(Id);
                if(user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound("User not found");
                }

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"internal Server Error : {ex.Message}");

            }
        }
        
        
    }
}

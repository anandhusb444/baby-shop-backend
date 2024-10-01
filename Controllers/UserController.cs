using baby_shop_backend.DTO;
using baby_shop_backend.Models.UserModel;
using baby_shop_backend.Services.userServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices;

namespace baby_shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserServies _user;
        private readonly IConfiguration _configer;
        private ILogger<UserController> _logger;

        public UserController(IuserServies userservise, IConfiguration config, ILogger<UserController> loger)
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

                var user = await _user.GetAllUsers();
                if(user == null || !user.Any())
                {
                    return NotFound("User Not Found");
                    _logger.LogInformation($"{user}");
                }
                else
                {
                    _logger.LogInformation($"Found {user.Count()} users.");
                    return Ok(user);
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"There is a error generated in the GetAlluser");
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
                    _logger.LogInformation($"{user}");
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

        [HttpPost ("Register")]
        public async Task<IActionResult> AddUsers(UserDTO userdto)
        {
            try
            {
                var user = await _user.User_Register(userdto);
                if(user == null)
                {
                    return BadRequest("Please Login");
                }
                else
                {
                    return Ok("Sucessfully Registerd");
                }

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"internal Server Error : {ex.Message}");

            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                var user_Login = await _user.Login(login);

                if (user_Login == "Not Found")
                {
                    return BadRequest("Please Sign Up");
                }
                if (user_Login == "Wrong Password")
                {
                    return BadRequest("Wrong Password");
                }
                if (user_Login == "user is bloked")
                {
                    return StatusCode(404, "Forbiden");
                }
                return Ok(new { Token = user_Login });
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"internal server error :{ex.Message}");
            }
            

        }
        [Authorize(Roles = "Admin")]
        [HttpPut("block {Id}")]
        public async Task<IActionResult> blokeUser(int Id)
        {
            try
            {
                var user = await _user.BlockUser(Id);

                if(user == null)
                {
                    return BadRequest("No user found");
                }
                else
                {
                    return Ok();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex.Message}");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Unblock {Id}")]

        public async Task<IActionResult> Unblock(int Id)
        {
            try
            {
                var user = _user.UnblockUser(Id);

                if(user == null)
                {
                    return BadRequest("user Not Found");
                }
                else
                {
                    return Ok();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server Error : {ex.Message}");
            }
        }
    }
}

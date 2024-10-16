using baby_shop_backend.DTO;
using baby_shop_backend.Models.UserModel;
using baby_shop_backend.Respones;
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

                    _logger.LogInformation($"{user}");
                    return NotFound(new GenericApiRespones<object>(400, "User Not found", user));
                }
                else
                {
                    _logger.LogInformation($"Found {user.Count()} users.");
                    return Ok(new GenericApiRespones<object>(200, "Ok", user));
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"There is a error generated in the GetAlluser");
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500, respones);

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
                    return Ok(new GenericApiRespones<object>(200, "Ok", user));
                }
                else
                {
                    return NotFound(new GenericApiRespones<object>(400, "User not found", null));
                }

            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500, respones);

            }
        }

        [HttpPost ("Register")]
        public async Task<IActionResult> AddUsers(UserDTO userdto)
        {
            try
            {
                var user = await _user.User_Register(userdto);
                if(user)
                {
                    return Ok(new GenericApiRespones<object>(200, "Sucessfully Registerd", user));

                }
                else
                {
                    return BadRequest(new GenericApiRespones<object>(400, "User already existed",user));

                }

            }
            catch(Exception ex)
            {
                var res = new GenericApiRespones<object>(500, "Internal Server error", null, ex.Message);
                return StatusCode(500, res);

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
                    return BadRequest(new GenericApiRespones<object>(400, "Please Sign Up", null));
                }
                if (user_Login == "Wrong Password")
                {
                    return BadRequest(new GenericApiRespones<object>(400, "Wrong Password", null));
                    
                }
                if (user_Login == "user is blocked")
                {
                    return BadRequest(new GenericApiRespones<object>(404, "Forbiden user", null));
                }
                return Ok(new GenericApiRespones<object>(200,"user logined Succesfuly", user_Login ));
            }
            catch(Exception ex)
            {

                var respones = new GenericApiRespones<object>(500, "Internal Server error", null, ex.Message);
                return StatusCode(500,respones);
            }
            

        }
        [Authorize(Roles = "Admin")]
        [HttpPut("block{Id}")]
        public async Task<IActionResult> blokeUser(int Id)
        {
            try
            {
                var user = await _user.BlockUser(Id);

                if(user == null)
                {
                    return BadRequest(new GenericApiRespones<object>(400, "No user found",null));
                }
                else
                {
                    return Ok(new GenericApiRespones<object>(200,"user blocked",user));
                }
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "internal server error", null, ex.Message);
                return StatusCode(500,respones);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Unblock {Id}")]

        public async Task<IActionResult> Unblock(int Id)
        {
            try
            {
                var user = await _user.UnblockUser(Id);

                if(user == null)
                {
                    return BadRequest(new GenericApiRespones<object>(400, "user Not Found", null));
                }
                else
                {
                    return Ok(new GenericApiRespones<object>(200,"user Unblocked",user));
                }
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(500,respones);
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            try
            {
                var result = await _user.DeleteUser(Id);

                if (result)
                {
                    return Ok(new GenericApiRespones<object>(200,"user as been deleted",result));
                }
                else
                {
                    return BadRequest(new GenericApiRespones<object>(400,"can delete user",null));
                }
            }
            catch(Exception ex)
            {
                var respones = new GenericApiRespones<object>(500, "Internal server error", null, ex.Message);
                return StatusCode(400, respones);
            }
        }
    }
}

using AutoMapper;
using baby_shop_backend.Context;
using baby_shop_backend.DTO;
using baby_shop_backend.Models.UserModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace baby_shop_backend.Services.userServices
{
    public class UserServies : IuserServies
    {
        private readonly DbContext_Main _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<UserServies> _logger;

        public UserServies(DbContext_Main context, IConfiguration config, IMapper map, ILogger<UserServies> loger)
        {
            _context = context;
            _configuration = config;
            _mapper = map;
            _logger = loger;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = await _context.User.ToListAsync();
                var userDTO = _mapper.Map<List<UserDTO>>(users);
                //_logger.LogInformation($"{userDTO}");
                return userDTO;


            }
            catch(Exception ex)
            {
                //throw new Exception(ex.Message);
                Console.WriteLine($"there is some error in the GetAllUsers method : {ex.Message}");
                return null;
            }
        }

        public async Task<UserDTO> GetUserById(int Id)
        {
            try
            {
                var userById = await _context.User.FirstOrDefaultAsync(u => u.id == Id);
                if(userById != null)
                {
                    var users = _mapper.Map<UserDTO>(userById);
                    return users;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> User_Register(UserDTO userdto)
        {
            try
            {
                var isUserExist = await _context.User.FirstOrDefaultAsync(u => u.userEmail == userdto.userEmail );
                if (isUserExist == null)
                {
                    var salt = BCrypt.Net.BCrypt.GenerateSalt();
                    var haspassword = BCrypt.Net.BCrypt.HashPassword(userdto.password, salt);
                    var addUser = new User() { userName = userdto.userName, userEmail = userdto.userEmail, password = haspassword };
                    await _context.User.AddAsync(addUser);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;   

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> Login(Login login)
        {
            try
            {
                var isExist = await _context.User.FirstOrDefaultAsync(u => u.userEmail == login.Email);

                if (isExist != null) 
                {
                    var userPassword = BCrypt.Net.BCrypt.Verify(login.Password, isExist.password);

                    if (userPassword)
                    {
                        if (isExist.isStatus == false)
                        {
                            return "user is blocked";
                        }
                        else
                        {
                           
                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                            var claims = new[]
                            {
                                new Claim(ClaimTypes.NameIdentifier, isExist.id.ToString()),
                                new Claim(ClaimTypes.Name, isExist.userName),
                                new Claim(ClaimTypes.Role, isExist.Role),
                                new Claim(ClaimTypes.Email, isExist.userEmail),

                            };

                            var token = new JwtSecurityToken(
                                claims: claims,
                                signingCredentials: credential,
                                expires: DateTime.Now.AddDays(1));
                            _logger.LogInformation($"Generated Token: {token}");
                            return new JwtSecurityTokenHandler().WriteToken(token);      
                        }
                    }
                    else
                    {
                        return "Wrong Password";
                    }
                };
                return "Not Found";
            }
            catch (Exception ex)
            {
                return $"an error Ocuuerd {ex.Message}";
            }

        }

        public async Task<bool> BlockUser(int Id)
        {
            
                var user = await _context.User.FirstOrDefaultAsync(u => u.id == Id);

                if(user == null)
                {
                    return false;
                }
             
             
                else
                {
                    user.isStatus = false;
                    await _context.SaveChangesAsync();
                    return true;
                }
            
        }

        public async Task<bool> UnblockUser(int Id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.id == Id);
            
            if(user == null)
            {
                return false;
            }
            else
            {
                user.isStatus = true;
                await _context.SaveChangesAsync();
                return true;
            }
        }

            public async Task<bool> DeleteUser(int Id)
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.id == Id);

                if(user != null)
                {
                    _context.User.Remove(user);
                    await _context.SaveChangesAsync();
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }

   
}

using AutoMapper;
using baby_shop_backend.Context;
using baby_shop_backend.DTO;
using baby_shop_backend.Models.UserModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;

namespace baby_shop_backend.Services.userServices
{
    public class UserServies : IuserServies
    {
        private readonly DbContext_Main _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<User> _logger;

        public UserServies(DbContext_Main context, IConfiguration config, IMapper map, ILogger<User> loger)
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

                return userDTO;


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDTO> GetUserById(int Id)
        {
            try
            {
                var userById = _context.User.FirstOrDefaultAsync(u => u.id == Id);
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
                var isUserExist = _context.User.FirstOrDefaultAsync(u => u.userEmail == userdto.userEmail);
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






    }
}

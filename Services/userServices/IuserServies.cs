﻿using baby_shop_backend.DTO;
using baby_shop_backend.Models.UserModel;

namespace baby_shop_backend.Services.userServices
{
    public interface  IuserServies
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();

        Task<UserDTO> GetUserById(int Id);

        Task<bool> User_Register(UserDTO userdto);

        Task<string> Login(Login login);

        Task<bool> BlockUser(int Id);

        Task<bool> UnblockUser(int Id);

        Task<bool> DeleteUser(int Id);



    }
}

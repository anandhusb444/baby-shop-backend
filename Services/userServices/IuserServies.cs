using baby_shop_backend.DTO;

namespace baby_shop_backend.Services.userServices
{
    public interface  IuserServies
    {
        Task<List<UserDTO>> GetAllUsers();

        Task<UserDTO> GetUserById();

    }
}

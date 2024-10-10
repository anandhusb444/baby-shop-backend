using baby_shop_backend.DTO.WhishListDTO;

namespace baby_shop_backend.Services.WhisListServices
{
    public interface IwhishList
    {
        Task<bool> AddToWhishList(string token, int productId);

        Task <bool> RemoveFromWhisList(string token, int productId);

        Task<List<OutWhishListDTO>> GetWhisList(string token);


    }
}

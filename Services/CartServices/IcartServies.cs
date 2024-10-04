using baby_shop_backend.DTO.CartDTO;

namespace baby_shop_backend.Services.CartServices
{
    public interface IcartServies
    {
        Task<List<OutCartDTO>> GetAllProducts(string token);

        Task<bool> AddToCart(string token, int productId);

        Task<bool> RemoveCart(string token, int productId);

        Task<bool> IncreaseQty(string token, int productId);

        Task<bool> DecreaseQty(string token, int productId);

    }
}

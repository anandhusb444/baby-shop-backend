using baby_shop_backend.Context;
using baby_shop_backend.DTO.CartDTO;
using baby_shop_backend.Services.JwtServies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace baby_shop_backend.Services.CartServices
{
    public class CartServies //: IcartServies 
    {
        private DbContext_Main _context;
        private readonly I_jwtServices _jwtServices;
        private IConfiguration _configuration;

        public CartServies(I_jwtServices jwtSer, IConfiguration config, DbContext_Main conxt)
        {
            _context = conxt;
            _jwtServices = jwtSer;
            _configuration = config;
        }

        public async Task<List<OutCartDTO>> GetAllProducts(string token)
        {
            try
            {
                var userId = _jwtServices.GetUserId(token);

                var user = await _context.User.Include(u => u.cart)
                    .ThenInclude(cart => cart.cartItems)
                    .ThenInclude(ci => ci.product)
                    .FirstOrDefaultAsync(us => us.id == userId);

                if (user == null)
                {
                    throw new Exception("user not found");

                }
                if(user.cart == null || !user.cart.cartItems.Any())
                {
                    return new List<OutCartDTO>();
                }
                var items = user.cart.cartItems.Select(itm => new OutCartDTO 
                { 
                    id = itm.productId,
                    title = itm.product.title,
                    description = itm.product.description,
                    //--------img------------
                    price = itm.product.price * itm.quantity,
                    quantity = itm.quantity,
                    total = itm.quantity * itm.product.price
                
                }).ToList();

                return items;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"there is error in the GetAllProduct : {ex.Message}");
                throw new Exception(ex.Message);
                
            }
            
        }
    }
}

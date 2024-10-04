using baby_shop_backend.Context;
using baby_shop_backend.DTO.CartDTO;
using baby_shop_backend.Models;
using baby_shop_backend.Services.JwtServies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace baby_shop_backend.Services.CartServices
{
    public class CartServies : IcartServies 
    {
        private DbContext_Main _context;
        private readonly I_jwtServices _jwtServices;
        private IConfiguration _configuration;
        //private ILogger _logger;

        public CartServies(I_jwtServices jwtSer, IConfiguration config, DbContext_Main conxt)
        {
            _context = conxt;
            _jwtServices = jwtSer;
            _configuration = config;
            //_logger = log;
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
                    image = $"{_configuration["HostUrl:image"]}/Products/{itm.product.image}",
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

        public async Task<bool> AddToCart(string token, int productId)
        {
            try
            {
                var userId = _jwtServices.GetUserId(token);

                var user = await _context.User.Include(c => c.cart)
                    .ThenInclude(c => c.cartItems)
                    .ThenInclude(c => c.product).FirstOrDefaultAsync(us => us.id == userId);

                if(user == null)
                {
                    return false;
                }

                var product = await _context.ProductsTable.FirstOrDefaultAsync(p => p.id == productId);
                if(product == null)
                {
                    return false;
                }

                if(user.cart == null)
                {
                    user.cart = new Cart { UserId = user.id, cartItems = new List<CartItems>() };
                    _context.CartTable.Add(user.cart);
                }

                var checkIsProduct = user.cart.cartItems.FirstOrDefault(v => v.productId == productId);
                if(checkIsProduct != null)
                {
                    return false;
                }
                else
                {
                    var cartItem = new CartItems 
                    {
                        cartId = user.cart.id,
                        productId = productId,
                        quantity = 1
                    };
                    user.cart.cartItems.Add(cartItem);
                    await _context.SaveChangesAsync();
                    return true;

                }
            }
            catch(Exception ex) 
            {
                // _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                //throw;
                Console.WriteLine($"There is some error in the AddCart  {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveCart(string token, int productId)
        {
            try
            {
                var userID = _jwtServices.GetUserId(token);

                var user = await _context.User.Include(u => u.cart)
                    .ThenInclude(ci => ci.cartItems)
                    .ThenInclude(p => p.product).FirstOrDefaultAsync(p => p.id == userID);

                if(user == null)
                {
                    throw new Exception("user not found");
                }

                var deleteProduct = user.cart.cartItems.FirstOrDefault(p => p.productId == productId);

                if(deleteProduct == null)
                {
                    return false;
                }
                else
                {
                    user.cart.cartItems.Remove(deleteProduct);
                    await _context.SaveChangesAsync();
                    return true;
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IncreaseQty(string token,int productId)
        {
            try
            {
                var userId = _jwtServices.GetUserId(token);

                var user = await _context.User.Include(u => u.cart)
                    .ThenInclude(ci => ci.cartItems).ThenInclude(p => p.product).FirstOrDefaultAsync(u => u.id == userId);

                if (user == null)
                {
                    throw new Exception("User Not Found");
                }

                var item = user.cart.cartItems.FirstOrDefault(p => p.productId == productId);

                if(item == null)
                {
                    return false;
                }
                else
                {
                    item.quantity += 1;
                    await _context.SaveChangesAsync();
                    return true;
                }
  
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

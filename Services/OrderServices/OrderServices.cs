using baby_shop_backend.Context;
using baby_shop_backend.DTO.OrderDTO;
using baby_shop_backend.Models;
using baby_shop_backend.Services.JwtServies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace baby_shop_backend.Services.OrderServices
{
    public class OrderServices : IorderServices
    {
        private readonly DbContext_Main _context;
        private readonly I_jwtServices _jwtServices;

        public OrderServices(DbContext_Main ctx, I_jwtServices services)
        {
            _context = ctx;
            _jwtServices = services;
        }

        public async Task<bool> OrderCreated(string token,OrderDTO orderdto)
        {
            try
            {
                var userId = _jwtServices.GetUserId(token);

                var user = await _context.User.Include(c => c.cart)
                    .ThenInclude(ci => ci.cartItems)
                    .ThenInclude(p => p.product).FirstOrDefaultAsync(p => p.id == userId);

                if (user == null || user.cart == null || user.cart.cartItems == null )
                {
                    //return false;
                    throw new Exception("cart is Empty order cannot placed");
                    
                }

                decimal Total = user.cart.cartItems.Sum(ci => ci.product.price * ci.quantity);

                var order = new Order
                {
                    UserId = userId,
                    userAddress = orderdto.userAddress,
                    userPhone = orderdto.userPhone,
                    orderDate = orderdto.orderDate,
                    total = Total,
                    orderItems = user.cart.cartItems.Select(ct => new OrderItems
                    {
                        productId = ct.productId,
                        productName = ct.product.title,
                        quantity = ct.quantity,
                        price = ct.quantity * ct.product.price
                    }).ToList()

                };
                _context.OrderTable.Add(order);
                await _context.SaveChangesAsync();
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<OutOrderDTO>> GetOrders(string token)
        {
            try
            {
                var userId = _jwtServices.GetUserId(token);

                var user = await _context.OrderTable.Include(oi => oi.orderItems)
                    .ThenInclude(p => p.products).FirstOrDefaultAsync(user => user.UserId == userId);

                if(user == null)
                {
                    return new List<OutOrderDTO>();
                }
                else
                {
                    var details = user.orderItems.Select(item => new OutOrderDTO
                    {
                        id = item.id,
                        productId = item.productId,
                        productName = item.productName,
                        quantity = item.quantity,
                        total = item.price
                    }).ToList();
                    return details;
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There is some error in the Get Order: ");
                return null;
            }

        }

        public async Task<List<OutOrderDTO>> GetOdersAdmin(int Id)
        {
            try
            {
                var user = _context.User.FirstOrDefaultAsync(us => us.id == Id);

                if(user == null)
                {
                    throw new Exception("user not found");
                }

                var orders = await _context.OrderTable.Include(oi => oi.orderItems)
                        .ThenInclude(p => p.products)
                        .Where(u => u.UserId == Id).ToListAsync();

                if(orders == null)
                {
                    return new List<OutOrderDTO>();
                }

                var details = new List<OutOrderDTO>();

                foreach(var order in orders)
                {
                    foreach(var item in order.orderItems)
                    {
                        details.Add(new OutOrderDTO
                        {
                            id = item.id,
                            productId = item.productId,
                            productName = item.productName,
                            quantity = item.quantity,
                            total = item.price * item.quantity,
                        });
                    }
                }
                return details;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

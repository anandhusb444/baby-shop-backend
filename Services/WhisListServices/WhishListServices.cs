using AutoMapper;
using baby_shop_backend.Context;
using baby_shop_backend.DTO.WhishListDTO;
using baby_shop_backend.Models;
using baby_shop_backend.Services.JwtServies;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace baby_shop_backend.Services.WhisListServices
{
    public class WhishListServices : IwhishList
    {
        private readonly I_jwtServices _jwtServices;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly DbContext_Main _context;

        public WhishListServices(I_jwtServices jwtservices, IMapper map, IConfiguration config,DbContext_Main context)
        {
            _jwtServices = jwtservices;
            _mapper = map;
            _configuration = config;
            _context = context;
        }

        public async Task<bool> AddToWhishList(string token , int productId)
        {
            try
            {
                var userId = _jwtServices.GetUserId(token);

                var user = await _context.User.Include(w => w.whishLists)
                    .ThenInclude(p => p.Products)
                    .FirstOrDefaultAsync(u => u.id == userId);

                if(user == null)
                {
                    throw new Exception("User is Not Found");
                }

                var product = user.whishLists.FirstOrDefault(wh => wh.productId == productId);

                if(product == null)
                {
                    var items = new AddWhishListDTO
                    {
                        productId = productId,
                        UserId = userId,
                    };
                    var map = _mapper.Map<WhishList>(items);
                    _context.WhishListTable.Add(map);
                    await _context.SaveChangesAsync();
                    return true;
                }
                _context.WhishListTable.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveFromWhisList(string token, int productId)
        {
            
                var userId = _jwtServices.GetUserId(token);

                if(userId == null)
                {

                    throw new Exception("User Not Found");
                
                }

                var whislList = await _context.WhishListTable.FirstOrDefaultAsync(wh => wh.productId == productId);

                if(whislList != null)
                {
                    _context.WhishListTable.Remove(whislList);
                    await _context.SaveChangesAsync();
                    return true;
               
                }
            return false;
            
            
        }

        public async Task<List<OutWhishListDTO>> GetWhisList(string token)
        {
            try
            {
                var userId = _jwtServices.GetUserId(token);

                if(userId == null)
                {
                    throw new Exception("No user Found");
                }

                var wishItems = await _context.WhishListTable.Include(p => p.Products)
                    .ThenInclude(c => c.category)
                    .Where(u => u.UserId == userId).ToListAsync();

                if(wishItems != null)
                {
                    var whishView = wishItems.Select(u => new OutWhishListDTO
                    {
                        id = u.id,
                        productId = u.productId,
                        description = u.Products.description,
                        price = u.Products.price,
                        category = u.Products.category.CategoriesName,
                        image = u.Products.image,
                    }).ToList();

                    return whishView;
                }
                else
                {
                    return new List<OutWhishListDTO>();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}

using AutoMapper;
using baby_shop_backend.Context;
using baby_shop_backend.DTO.CategoryDTO;
using baby_shop_backend.DTO.ProductDTO;
using baby_shop_backend.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace baby_shop_backend.Services.ProductServices
{
    public class ProductServices : IproductServices
    {
        private DbContext_Main _context;
        private IMapper _mapper;
        private ILogger<ProductServices> _loger;
        private IWebHostEnvironment _webHostEnviroment;
        private IConfiguration _configuratoin;

        public ProductServices(DbContext_Main context, IMapper map, IWebHostEnvironment webHost, IConfiguration config, ILogger<ProductServices> log)
        {
            _context = context;
            _mapper = map;
            _loger = log;
            _webHostEnviroment = webHost;
            _configuratoin = config;
        }

        public async Task<List<ProductViewDTO>> GetAllProducts()
        {
            try
            {
                var product = await _context.ProductsTable.Include(p => p.category).Where(pr => pr.status == true).ToListAsync();

                if (product.Any())
                {
                    var products = product.Select(p => new ProductViewDTO 
                    { 
                        id = p.id,
                        title = p.title,
                        description = p.description,
                        image = $"{_configuratoin["HostUrl:image"]}/Products/{p.image}",
                        category = p.category.CategoriesName,
                        price = p.price
                    
                    }).ToList();
                    return products;

                }
                return new List<ProductViewDTO>();
            }
            catch(Exception ex)
            {
                _loger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductViewDTO> GetProductsById(int Id)
        {
            try
            {
                var product = await _context.ProductsTable.Include(p => p.category).FirstOrDefaultAsync(pr => pr.id == Id);
                if(product == null || product.status == false)
                {
                    return new ProductViewDTO();
                }
                else
                {
                    var products = _mapper.Map<ProductViewDTO>(product);
                    products.image = $"{_configuratoin["HostUrl:image"]}/Products/{products.image}";
                    return products;
                }
            }
            catch(Exception ex)
            {
                _loger.LogInformation(ex.Message);
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);

            }
        }

        public async Task<List<ProductViewDTO>> GetProductByCat(CategoryDTO category)
        {
            try
            {
                var products = _context.ProductsTable.Include(p => p.category).Where(p => p.category.CategoriesName == category.CategoryName && p.status == true);

                var productN = products.Select(pr => new ProductViewDTO
                {
                    id = pr.id,
                    title = pr.title,
                    description = pr.description,
                    image = $"{_configuratoin["HostUrl:image"]}/Products/{pr.image}",
                    price = pr.price,
                    category = pr.category.CategoriesName,
                    quantity = pr.quantity

                }).ToList();
                
                if(productN.Count > 0)
                {
                    return productN;
                }
                else
                {
                    return new List<ProductViewDTO>();
                }
            }
            catch(Exception ex)
            {
                _loger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductViewDTO>> Search(string Name)
        {
            try
            {
                var product = _context.ProductsTable.Include(p => p.category).Where(p => p.title.ToLower().Contains(Name.ToLower()) && p.status == true);

                var productN = product.Select(p => new ProductViewDTO
                {
                    id = p.id,
                    title = p.title,
                    description = p.description,
                    image = $"{_configuratoin["HostUrl:image"]}/Products/{p.image}",
                    quantity = p.quantity,
                    category = p.category.CategoriesName,
                    price = p.price

                }).ToList();

                if(productN.Count > 0)
                {
                    return productN;
                }
                else
                {
                    return new List<ProductViewDTO>();
                }
            }
            catch (Exception ex)
            {
                _loger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddProduct(AddProductDTO addproduct, IFormFile image)
        {
            try
            {
                var isExist = await _context.ProductsTable.FirstOrDefaultAsync(p => p.title == addproduct.title);
                if(isExist != null)
                {
                    return false;
                }

                var isCategory = _context.CategoriesTable.AnyAsync(c => c.id == addproduct.categoryId);
                if(isCategory == null)
                {
                    return false;
                }

                var product = _mapper.Map<Products>(addproduct);// add maping to the products

                if(image != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(_webHostEnviroment.WebRootPath, "Image", "products", fileName);

                    using (var strem = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(strem);
                    }

                    product.image = fileName;
                }

                await _context.ProductsTable.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _loger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateProduct(int Id, AddProductDTO product, IFormFile image)
        {
            try
            {
                var isExist = await _context.ProductsTable.FirstOrDefaultAsync(p => p.id == Id);
                if(isExist != null)
                {
                    if (image != null)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.Name);
                        var filePath = Path.Combine(_webHostEnviroment.WebRootPath, "Image", "Products", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                            isExist.image = fileName;
                        }
                    }


                    isExist.title = product.title;
                    isExist.description = product.description;
                    isExist.price = product.price;
                    isExist.categoryId = product.categoryId;
                    isExist.quantity = product.quantity;

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
                _loger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}

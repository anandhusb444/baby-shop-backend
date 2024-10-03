using baby_shop_backend.DTO.CategoryDTO;
using baby_shop_backend.DTO.ProductDTO;

namespace baby_shop_backend.Services.ProductServices
{
    public interface IproductServices
    {
        Task<List<ProductViewDTO>> GetAllProducts();
        Task<ProductViewDTO> GetProductsById(int Id);

        Task<List<ProductViewDTO>> GetProductByCat(CategoryDTO category);

        Task<List<ProductViewDTO>> Search(string Name);

        Task<bool> AddProduct(AddProductDTO addproduct, IFormFile image);

        Task<bool> UpdateProduct(int Id, AddProductDTO product, IFormFile image);

    }
}

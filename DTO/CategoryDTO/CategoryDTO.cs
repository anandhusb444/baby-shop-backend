using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.DTO.CategoryDTO
{
    public class CategoryDTO
    {
        [Required]
        public string CategoryName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.DTO.ProductDTO
{
    public class ProductDTO
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string image { get; set; }
        [Required]
        public decimal price { get; set; }

        [Required]
        public int categoryId { get; set; }
        [Required]
        public int quantity { get; set; }


    }
}

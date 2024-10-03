using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.DTO.ProductDTO
{
    public class AddProductDTO
    {
        [Required]
        
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int price { get; set; }
        [Required]

        public int categoryId { get; set; }
        [Required]
        public int quantity { get; set; }

    }
}

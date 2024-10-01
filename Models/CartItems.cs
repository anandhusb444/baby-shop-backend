using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.Models
{
    public class CartItems
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int cartId { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public int quantity { get; set;}

        public virtual Cart cart { get; set; }
        public virtual Products product { get; set; }

    }
}

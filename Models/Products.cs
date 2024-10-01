using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public string image { get; set; }

        [Required]
        public int categoryId { get; set; }
        [Required]
        public int quantity { get; set; }
        public bool status { get; set; } = true;
        public virtual Category category { get; set; }
        public ICollection<CartItems> cartItems { get; set; }
        public ICollection<OrderItems> orderitems { get; set; } 
        public ICollection<WhishList> whishlist { get; set; }
    }
}

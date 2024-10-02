using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.Models
{
    public class OrderItems
    {
        [Key]
        public int id { get; set; }

        [Required]

        public int orderId { get; set; }
        [Required]
        public int productId { get; set; }
        [Required]
        public string productName { get; set; }

        [Required]
        public decimal price { get; set; }
        public virtual Products products { get; set; }
        public virtual Order order { get; set; }
    }
}
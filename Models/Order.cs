using baby_shop_backend.Models.UserModel;
using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string userPhone { get; set; }

        [Required]
        public string userAddress { get; set; }
        [Required]
        public decimal total { get; set; }

        [Required]
        public DateTime orderDate { get; set; }
        public virtual User User { get; set; }
        public ICollection<OrderItems> orderItems { get; set; }



    }
}

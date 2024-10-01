using baby_shop_backend.Models.UserModel;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.Models
{
    public class Cart
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItems> cartItems { get; set; }

    }
}

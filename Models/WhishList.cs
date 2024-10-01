using baby_shop_backend.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace baby_shop_backend.Models
{
    public class WhishList
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public int productId { get; set; }
        public virtual User User { get; set; }
        public virtual Products Products { get; set; }

    }
}

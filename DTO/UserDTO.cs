using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.DTO
{
    public class UserDTO
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string userName { get; set; }
        [Required]
        public string userEmail { get; set; }
        [Required]
        [StringLength(100,MinimumLength = 8)]
        public string password { get; set; }
    }
}

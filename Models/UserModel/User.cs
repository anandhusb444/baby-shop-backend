using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.Models.UserModel
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        [EmailAddress]
        public string userEmail { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 8)]
        public string password { get; set; }

        public bool isStatus { get; set; } = true;
        public string Role { get; set; } = "User";



    }
}

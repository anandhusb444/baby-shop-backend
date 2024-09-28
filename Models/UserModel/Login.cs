using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.Models.UserModel
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

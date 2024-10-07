using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.DTO.OrderDTO
{
    public class OrderDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string userPhone { get; set; }
        [Required]
        public string userAddress { get; set; }
        [Required]
        public DateTime orderDate { get; set; }
    }
}

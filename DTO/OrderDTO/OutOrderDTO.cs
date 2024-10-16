namespace baby_shop_backend.DTO.OrderDTO
{
    public class OutOrderDTO
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public string productName { get; set; }

        //public DateTime orderDate { get; set; }
        public decimal total { get; set; }
    }
}

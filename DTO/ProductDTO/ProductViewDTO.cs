namespace baby_shop_backend.DTO.ProductDTO
{
    public class ProductViewDTO
    {
        public int id { get; set; }

        public string title { get; set; }
        public string description { get; set; }

        public decimal price { get; set; }
        public string image { get; set; }
        
        public string category { get; set; }
        public int quantity { get; set; }


    }
}

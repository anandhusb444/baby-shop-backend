namespace baby_shop_backend.DTO.WhishListDTO
{
    public class OutWhishListDTO
    {
        public int id { get; set; }
        public int productId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public string category { get; set; }


    }
}

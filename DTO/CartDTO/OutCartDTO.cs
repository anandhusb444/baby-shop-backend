namespace baby_shop_backend.DTO.CartDTO
{
    public class OutCartDTO
    {
        public  int id { get; set; }
        public String title { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }   
        public decimal total { get; set; }



    }
}

﻿namespace baby_shop_backend.DTO.CartDTO
{
    public class CartItemDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        
        public string description { get; set; }
        public  string image { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal priceTotal { get; set; }



    }
}

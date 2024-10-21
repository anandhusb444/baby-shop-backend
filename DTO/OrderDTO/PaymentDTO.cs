namespace baby_shop_backend.DTO.OrderDTO
{
    public class PaymentDTO
    {
        public string razorpay_paymeny_id { get; set; }
        public string razorpay_order_id { get; set; }
        public string razorpay_signature { get; set; }

    }
}

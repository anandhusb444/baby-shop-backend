using baby_shop_backend.DTO.OrderDTO;

namespace baby_shop_backend.Services.OrderServices
{
    public interface IorderServices
    {
        Task<bool> OrderCreated(string token, OrderDTO orderdto);

        Task<List<OutOrderDTO>> GetOrders (string token);

        Task<List<OutOrderDTO>> GetOdersAdmin(int Id);

        Task<decimal> TotalRevenue();

        Task<int> TotalPurchase();

        bool Payment(PaymentDTO razorpay);

    }
}

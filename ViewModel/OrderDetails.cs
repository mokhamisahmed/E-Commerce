using E_Commerce_WebSite.Models;

namespace E_Commerce_WebSite.ViewModel
{
    public class OrderDetails
    {

        public List<OrderItem> orderItems { get; set; }

        public String UserId { get; set; }

        public double total_price { get; set; }



    }
}

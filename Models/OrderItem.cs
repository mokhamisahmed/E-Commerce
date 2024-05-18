namespace E_Commerce_WebSite.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
          
    //    public int productId { get; set; }

      public Product product { get; set; }

        public int Quantity { get; set; }

        public double total_price { get; set; }
        
       // public int orderId { get; set; }

        public Order order { get; set; }



    }

}

namespace E_Commerce_WebSite.Models
{
    public class Order
    {

        public int Id { get; set; }
     //  public String userId { get; set; }
        public ApplicationUser user { get; set; }

        public String Order_Date { get; set; }

        public double totalAmount { get; set; }

        public List<OrderItem> orderItems { get; set; }

        public Boolean isAccept { get; set; }

        public Boolean isDeliver { get; set; }


    }
}

namespace E_Commerce_WebSite.Models
{
    public class Cart
    {

        public int Id { get; set; }

        public List<Product> Orderproducts = new List<Product>();

        //public int userId {get;set;}

        public ApplicationUser user { get; set; }


    }
}

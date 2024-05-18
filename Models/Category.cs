namespace E_Commerce_WebSite.Models
{
    public class Category
    {

        public int Id { get; set; }

        public String Name { get; set; }

        public List<Product> products { get; set; }

    }
}

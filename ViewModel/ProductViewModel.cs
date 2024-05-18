using E_Commerce_WebSite.Models;

namespace E_Commerce_WebSite.ViewModel
{
    public class ProductViewModel
    {
        public Product product { get; set; }

        public List<Product> products { get; set; }

       

        public List<Category> categories { get; set; }

    }
}

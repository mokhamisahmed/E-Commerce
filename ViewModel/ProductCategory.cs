using E_Commerce_WebSite.Models;

namespace E_Commerce_WebSite.ViewModel
{
    public class ProductCategory
    {

        public List<Product> products { get; set; }

        public List<Category> categories { get; set; }

        public List<Product> DiscountProducts { get; set; }

    }
}

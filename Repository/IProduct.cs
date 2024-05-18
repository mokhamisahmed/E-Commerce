using E_Commerce_WebSite.Models;

namespace E_Commerce_WebSite.Repository
{
    public interface IProduct:ICrud<Product>
    {

        public Task<List<Product>> GetProductsWithCategories();
        public Task<List<Product>> GetProductsDiscountWithCategories();


    }
}

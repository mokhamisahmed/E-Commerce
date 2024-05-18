using E_Commerce_WebSite.Database;
using E_Commerce_WebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebSite.Repository
{
    public class ProductService:Service<Product>,IProduct
    {
        private readonly Connection connection;
        public ProductService(Connection connection) :base(connection){

            this.connection = connection;
        }

        public async Task<List<Product>> GetProductsDiscountWithCategories()
        {
            return await this.connection.Products.Include(p => p.category).Where(p => p.StatusDiscount == true).ToListAsync();

        }

        public async Task<List<Product>> GetProductsWithCategories()
        {
            return await this.connection.Products.Include(p => p.category).Where(p=>p.StatusDiscount==false).ToListAsync();
        }
    }
}

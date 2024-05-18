using E_Commerce_WebSite.Database;
using E_Commerce_WebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebSite.Repository
{
    public class CategoryService : Service<Category>, ICategory
    {
        private readonly Connection connection;
        public CategoryService(Connection context) : base(context)
        {
            this.connection = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await this.connection.Categories.Include(c=>c.products).ToListAsync();
        }
    }
}

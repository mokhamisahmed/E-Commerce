using E_Commerce_WebSite.Models;

namespace E_Commerce_WebSite.Repository
{
    public interface ICategory:ICrud<Category>
    {
        public Task<List<Category>> GetCategories();

    }
}

using E_Commerce_WebSite.Models;

namespace E_Commerce_WebSite.Repository
{
    public interface IOrderItem:ICrud<Order>
    {
        public Task<List<Order>> GetOrdersWithOrderItems();
        public Task<List<Order>> GetOrdersWithOrderItems(int userId);

        public Task<int> UpdateAccept(int id);

        public Task<int> UpdateDeliver(int id);
    }
}

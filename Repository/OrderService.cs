using E_Commerce_WebSite.Database;
using E_Commerce_WebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebSite.Repository
{
    public class OrderService : Service<Order> , IOrderItem
    {
        private readonly Connection context;
        public OrderService(Connection context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Order>> GetOrdersWithOrderItems()
        {
            return await this.context.Orders.Include(o => o.orderItems).ThenInclude(oi=>oi.product).ToListAsync();
        }
        public async Task<List<Order>> GetOrdersWithOrderItems(int userId)
        {
            return await this.context.Orders.Include(o => o.orderItems).ThenInclude(oi => oi.product).ToListAsync();
        }

        public async Task<int> UpdateAccept(int id)
        {
            Order order =  this.context.Orders.Find(id);

            order.isAccept = true;
          return await this.context.SaveChangesAsync();
        }

        public async Task<int> UpdateDeliver(int id)
        {
            Order order = this.context.Orders.Find(id);

            order.isDeliver = true;
            return await this.context.SaveChangesAsync();

        }


    }
}

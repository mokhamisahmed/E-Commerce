using E_Commerce_WebSite.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebSite.Controllers
{
    public class UserController : Controller
    {
        private readonly IOrderItem order;

        public UserController(IOrderItem order)
        {
            this.order = order;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MyOrder(int id)
        {
            var Orders = await this.order.GetOrdersWithOrderItems(id);

            return View(Orders);

        }


    }
}

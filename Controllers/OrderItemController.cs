using E_Commerce_WebSite.Models;
using E_Commerce_WebSite.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebSite.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItem Items;

        public OrderItemController(IOrderItem Items)
        {

            this.Items = Items;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderWithOrderItem()
        {

            return View(await this.Items.GetOrdersWithOrderItems()); 

        }
        [HttpGet]
        public async Task<IActionResult> Accept(int id)
        {

            await this.Items.UpdateAccept(id);
            return RedirectToAction("GetOrderWithOrderItem");

        }
        [HttpGet]
        public async Task<IActionResult> Deliver(int id)
        {
            await this.Items.UpdateDeliver(id);
            return RedirectToAction("GetOrderWithOrderItem");
        }





    }
}

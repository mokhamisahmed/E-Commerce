using E_Commerce_WebSite.Models;
using E_Commerce_WebSite.Repository;
using E_Commerce_WebSite.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICrud<Order> order;
        private readonly ICrud<OrderItem> Items;


        public OrderController(ICrud<Order> order, ICrud<OrderItem> Items)
        {
            this.order = order;
            this.Items = Items;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MakeOrder(OrderDetails details)
        {


            Order order = new Order()
            {
                 Order_Date="1-5-2024",
                 //  userId=details.UserId,
                totalAmount = details.total_price



            };
       Order o=   await  this.order.Create(order);

        //  foreach (var item in details.orderItems)
        //    {
          //      item.orderId = o.Id;
              
            //    await this.Items.Create(item);

           // }
            return RedirectToAction("GetItems");


        } 

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {

            List<OrderItem> items =await this.Items.GetEntities();

            return Content("test");

        }

        
    }
}

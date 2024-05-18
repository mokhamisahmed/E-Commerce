using Microsoft.AspNetCore.Mvc;
using E_Commerce_WebSite.Models;
using Newtonsoft.Json;


namespace E_Commerce_WebSite.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetCartProduct()
        {

            if (HttpContext.Session.GetString("ListCart") != null)
            {



                Cart retrievedObject = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("ListCart"));


                return View(retrievedObject.Orderproducts);
            }
            return View();
        }

    }
}

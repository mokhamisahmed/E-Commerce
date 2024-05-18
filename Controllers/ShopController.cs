using E_Commerce_WebSite.Models;
using E_Commerce_WebSite.Repository;
using E_Commerce_WebSite.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce_WebSite.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProduct crud;
        private readonly ICategory category;
        public ShopController(IProduct crud, ICategory category)
        {
            this.crud = crud;

            this.category = category;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> GetProducts(Category category)
        {
            var categories = await this.category.GetCategories();
            List<Product> products=new List<Product>();

            for (int i=0;i<categories.Count;i++)
            {
                if (categories[i].Id==category.Id)
                {

                    products = categories[i].products;
                    break;                    

                }

            }
            string serializedObject = JsonConvert.SerializeObject(products);


            return Ok(serializedObject);


        }

        [Authorize]
        [HttpGet]
    
        public async Task<IActionResult> MakeShopping()
        {
            ProductCategory pc = new ProductCategory();

            pc.categories =  await category.GetCategories();

            pc.products = await this.crud.GetProductsWithCategories();

            pc.DiscountProducts = await this.crud.GetProductsDiscountWithCategories();

            return View(pc);
            
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Product product)
        {
            Product p = await this.crud.GetById(product.Id);
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("ListCart")))
            {

                Cart c = new Cart();
              
                c.Orderproducts.Add(p);

                string serializedObject = JsonConvert.SerializeObject(c);

                HttpContext.Session.SetString("ListCart",serializedObject);


            }
            else
            {
               Cart retrievedObject = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("ListCart"));

                retrievedObject.Orderproducts.Add(p);

                string serializedObject = JsonConvert.SerializeObject(retrievedObject);

                HttpContext.Session.SetString("ListCart", serializedObject);

            }
            return Ok();


        }







    }
}

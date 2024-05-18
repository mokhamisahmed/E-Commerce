using E_Commerce_WebSite.Models;
using E_Commerce_WebSite.Repository;
using E_Commerce_WebSite.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICrud<Category> crud;

       

        public CategoryController(ICrud<Category> crud)
        {
            this.crud = crud;

        }

       

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ManageCategory()
        {

          

            CategoryViewModel cvm = new CategoryViewModel() { 
            categories=await  this.crud.GetEntities()
         

            };
            return View(cvm);

        }

        [HttpPost]

        public async  Task<IActionResult> AddCategory(Category category) {

           await  this.crud.Create(category);
            return RedirectToAction("ManageCategory");
        
        }

        


    }
}

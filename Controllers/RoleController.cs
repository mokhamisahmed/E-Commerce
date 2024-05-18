using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebSite.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;

        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            IdentityRole role = new IdentityRole() { 
            Name="Admin"
            
            };
           await this.roleManager.CreateAsync(role);

            return Content("Done");

        }
    }
}

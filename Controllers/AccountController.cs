using E_Commerce_WebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using E_Commerce_WebSite.Database;
using E_Commerce_WebSite.ViewModel;
using AutoMapper;

namespace E_Commerce_WebSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private IMapper mapper;

        private readonly Connection context;

        public AccountController(Connection context,IMapper _mapper,RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.context = context;
            this.mapper = _mapper;
        
        }
        [HttpGet]

        public IActionResult LogIn()
        {

            return View();
        }

        [HttpGet]

        public IActionResult Test() {

            return Content("done");
        }

        [HttpGet]
        public IActionResult SignUp()
        {

            UserView userRoles = new UserView()
            {
                roles = this.roleManager.Roles.ToList(),
                userWithRoles = this.UsersRoles()

            };

            return View(userRoles);
        }
        [HttpPost]
         [ValidateAntiForgeryToken]
        public async  Task<IActionResult> LogIn(UserLogIn u) {


            if (ModelState.IsValid)
            {
                ApplicationUser user = await this.userManager.FindByEmailAsync(u.Email);

                if (user != null)
                {
                    bool isCorrect = await this.userManager.CheckPasswordAsync(user, u.Password);

                    if (isCorrect)
                    {

                        await this.signInManager.SignInAsync(user, false);

                        return RedirectToAction("Test");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "password invalid");
                        return View(u);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "username and password invalid");
                    return View(u);
                }



            }

            return View(u);



        }


        [HttpPost]

        public async Task<IActionResult> SignUp(UserRegister u)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = this.mapper.Map<ApplicationUser>(u);

                var result = await this.userManager.CreateAsync(user, u.Password);

                if (result.Succeeded)
                {
                    var RoleName = roleManager.Roles.SingleOrDefault(r => r.Id == u.role_id);
                    if (RoleName != null)
                    {
                        await this.userManager.AddToRoleAsync(user, RoleName.Name);

                    }

                    UserView userRoles = new UserView()
                    {
                        roles = this.roleManager.Roles.ToList(),
                        userWithRoles = this.UsersRoles()

                    };
                    return View(userRoles);
                }

            }


            return View();
        }

       
        private List<UserRole> UsersRoles()
        {

            List<UserRole> userRoles = (from userRole in context.UserRoles
                                        join user in context.Users on userRole.UserId equals user.Id
                                        join role in context.Roles on userRole.RoleId equals role.Id
                                        select new UserRole
                                        {
                                            user = new ApplicationUser()
                                            {
                                                Id = user.Id,
                                                UserName = user.UserName,
                                                Email = user.Email,

                                            },
                                            role = new IdentityRole()
                                            {
                                                Name = role.Name
                                            }





                                        }).ToList();

            return userRoles;


        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

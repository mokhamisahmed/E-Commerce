using E_Commerce_WebSite.Models;
using E_Commerce_WebSite.Repository;
using E_Commerce_WebSite.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebSite.Controllers
{
    public class ProductController : Controller
    {

        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IProduct crudProduct;
        private readonly ICrud<Category> crudCategory;


        public ProductController(IProduct crudProduct, ICrud<Category> crudCategory,IWebHostEnvironment webHostEnvironment)
        {
            this.crudProduct = crudProduct;
            this.crudCategory = crudCategory;
            this.webHostEnvironment = webHostEnvironment;

        }


        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]

        public async Task<IActionResult> ManageProduct() {

            ProductViewModel pvm = new ProductViewModel() {
                
            products=await this.crudProduct.GetEntities(),

            categories= await this.crudCategory.GetEntities(),

         
         
            
            };

            return View(pvm);

        }

       

        [HttpPost]

        public async  Task<IActionResult> AddProduct(Product product)
        {
            if (product.DiscountValue!=0) {

                product.priceAfterDiscount = product.price - product.DiscountValue;

                product.StatusDiscount = true;

            }
           

            product.Image_path = await this.UploadFile(product.file);
            await this.crudProduct.Create(product);

            return RedirectToAction("ManageProduct");
        }

        private async Task<String> UploadFile(IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string UploadDir = Path.Combine(this.webHostEnvironment.WebRootPath, "Images");

                fileName = Guid.NewGuid().ToString() + "." + file.FileName;

                String FilePath = Path.Combine(UploadDir, fileName);

                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {

                    await file.CopyToAsync(fileStream);
                    return "/Images/" + fileName;
                }


            }

            return null;

        }




    }
}

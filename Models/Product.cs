using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace E_Commerce_WebSite.Models
{
    public class Product
    {

        public int Id { get; set; }

        public String Name { get; set; }

        public int Quantity {get;set;}

        public String Unit { get; set; }

        public double price { get; set; }

        public String Image_path { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }

       public int categoryId { get; set; }

        [JsonIgnore]
        public Category category { get; set; }


        public double priceAfterDiscount { get; set; }

        public double DiscountValue { get; set; }

        public Boolean StatusDiscount { get; set; }

    }
}

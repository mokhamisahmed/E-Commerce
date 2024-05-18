using Microsoft.AspNetCore.Identity;

namespace E_Commerce_WebSite.Models
{
    public class ApplicationUser:IdentityUser
    {

        public ApplicationUser()
        {

            IdentityUserRole<int> t = new IdentityUserRole<int>();

            
           
        }
     public String Address { get; set; }

     


    }
}

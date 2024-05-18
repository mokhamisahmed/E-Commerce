using E_Commerce_WebSite.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_WebSite.ViewModel
{
    public class UserRole:IdentityUserRole<int>
    {
        public ApplicationUser user { get; set; }

        public IdentityRole role { get; set; }


    }
}

using Microsoft.AspNetCore.Identity;

namespace E_Commerce_WebSite.ViewModel
{
    public class UserView
    {
        public List<IdentityRole> roles { get; set; }
        public List<UserRole> userWithRoles { get; set; }

    }
}

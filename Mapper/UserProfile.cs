using E_Commerce_WebSite.Models;
using E_Commerce_WebSite.ViewModel;
using AutoMapper;
namespace E_Commerce_WebSite.Mapper
{
    public class UserProfile:Profile
    {

        public UserProfile()
        {

            CreateMap<UserRegister, ApplicationUser>();
        }
    }
}

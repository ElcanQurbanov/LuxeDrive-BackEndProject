using Microsoft.AspNetCore.Identity;

namespace Final_Project_RentApp.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool RememberMe { get; set; }
    }
}

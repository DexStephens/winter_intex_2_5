using Microsoft.AspNetCore.Identity;

namespace winter_intex_2_5.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

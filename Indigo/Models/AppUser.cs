using Microsoft.AspNetCore.Identity;

namespace Indigo.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}

using Indigo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Indigo.areas.Manage.Controllers
{
    [Area("Manage")]
    
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser user = new AppUser
            {
                UserName="SuperAdmin",
                Fullname="Super admin"
            };
           var result = await _userManager.CreateAsync(user,"Admin123");
            return Ok(result);
        }
    }
}

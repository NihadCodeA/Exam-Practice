using Indigo.Helpers;
using Indigo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace Indigo.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {

        public AccountController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Login(AppUser user)
        {
            return RedirectToAction("Index", "Dashboard");
        }



    }
}

using Indigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Indigo.Controllers
{
    public class HomeController : Controller
    {

        private readonly IndigoContext _context;

        public HomeController(IndigoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 
            List<Post> posts = _context.Posts.ToList();
            return View(posts);
        }

    }
}
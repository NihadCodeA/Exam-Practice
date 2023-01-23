using Indigo.Helpers;
using Indigo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Indigo.areas.Manage.Controllers
{
    [Area("Manage")]
    public class PostController : Controller
    {
        private readonly IndigoContext _context;
        private readonly IWebHostEnvironment _env;

        public PostController(IndigoContext context,IWebHostEnvironment env) 
        { 
            _context= context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Post> posts=_context.Posts.ToList();
            return View(posts);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (post == null) return NotFound();
            if(!ModelState.IsValid) return View();
            if (post.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile","The Image field is required!");
                return View();
            }
            else
            {
                post.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/posts", post.ImageFile);
            }
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Post post = _context.Posts.Find(id);
            if (post == null) return NotFound();
            return View(post);
        }
        [HttpPost]
        public IActionResult Update(Post post)
        {
            Post existPost = _context.Posts.Find(post.Id);
            if (existPost == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (post.ImageFile != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/posts", existPost.Image);
                existPost.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/posts", post.ImageFile);
            }
            existPost.Title= post.Title;
            existPost.Description= post.Description;
            existPost.RedirectText= post.RedirectText;
            existPost.RedirectUrl= post.RedirectUrl;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Post post = _context.Posts.FirstOrDefault(x=>x.Id==id);
            if(post == null) return NotFound();
            if(post.Image != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/posts", post.Image);
            }
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

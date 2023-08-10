using EF_Lecture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EF_Lecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        //Need to add to get db access
        private BirdDbContext _birdDbContext = new BirdDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Post> result =_birdDbContext.Posts.ToList();  //
            return View(result);
        }

        public IActionResult Details(int id)
        {
            Post p = _birdDbContext.Posts.FirstOrDefault(x => x.Id == id);
            //option 1
            //make a new model that contains all you want to bring down
            //option2
            //send it through a viewdata
            ViewBag.Comments = _birdDbContext.Comments.Where(c => c.PostId == id).ToList();
            return View(p);
        }

        public IActionResult AddComment(Comment c)
        {
            _birdDbContext.Comments.Add(c);
            _birdDbContext.SaveChanges();
            return RedirectToAction("Details", new { id = c.PostId });
        }

        public IActionResult AddPost(Post p)
        {
            p.DatePosted = DateTime.Now;
            _birdDbContext.Posts.Add(p);
            _birdDbContext.SaveChanges();
            //Any time you make changes, save it

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
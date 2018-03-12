using LionsFeed.Data;
using LionsFeed.Models;
using LionsFeed.ViewModel.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace LionsFeed.Controllers
{
    public class HomeController : Controller
    {

        private LionsContext _context;
        public HomeController(LionsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("User"))
            {
                return RedirectToAction("HomeView");
            }
            else
                return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult HomeView()
        {
            var allPosts = _context.Posts
                .Include(p => p.Artist);

            var viewModel = new PostViewModel
            {
                Posts = allPosts.OrderByDescending(p=>p.CreatedDate)
            };

            return View(viewModel);
        }
    }
}

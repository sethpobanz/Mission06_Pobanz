using Microsoft.AspNetCore.Mvc;
using Mission06_Pobanz.Models;
using System.Diagnostics;

namespace Mission06_Pobanz.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private Mission6ApplicationContext _context;

        public HomeController(Mission6ApplicationContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult addPage()
        {
            ViewBag.Categories = _context.Categories.OrderBy(x => x.Category).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult addPage(Movies response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            ViewBag.Categories = _context.Categories.OrderBy(x => x.Category).ToList(); // Repopulate ViewBag.Categories

            return View();
        }

        public IActionResult table()
        {
            var movies = _context.Movies.OrderBy(x => x.Year).ToList();

            return View(movies);
        }

        public IActionResult Edit()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View("addPage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

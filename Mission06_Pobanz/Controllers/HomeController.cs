using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Pobanz.Models;
using System.Diagnostics;

namespace Mission06_Pobanz.Controllers
{
    public class HomeController : Controller
    {
      

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

            return View(new Movies());
        }

        [HttpPost]
        public IActionResult addPage(Movies response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            ViewBag.Categories = _context.Categories.OrderBy(x => x.Category).ToList(); // Repopulate ViewBag.Categories

            return RedirectToAction("table");
        }

        public IActionResult table()
        {
            var movies = _context.Movies.Include(x => x.Categories).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList();

            return View("addPage", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedMovie) 
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();

            return RedirectToAction("table");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var recordToDelete = _context.Movies.Single(y => y.MovieId == id);

            return View(recordToDelete);
        
        }

        [HttpPost]
        public IActionResult Delete(Movies movies)
        {
            _context.Movies.Remove(movies);
            _context.SaveChanges();
            return RedirectToAction("table");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

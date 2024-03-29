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
            return View();
        }
        
        [HttpPost]
        public IActionResult addPage(Application response)
        {
            _context.Applications.Add(response);
            _context.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

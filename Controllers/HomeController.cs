using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDbContext _context;

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movies()
        {
            return View(_context.Movies);
        }
        public IActionResult Podcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(MovieModel movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return View("Success", movie);
        }
        public IActionResult EditMovie(int mid)
        {
            var movie = _context.Movies.Where(m => m.ID == mid).FirstOrDefault();
            return View(movie);
        }
        [HttpPost]
        public IActionResult EditMovie(MovieModel movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return View("Success", movie);
        }
        public IActionResult DeleteMovie(int mid)
        {
            _context.Movies.Remove(_context.Movies.Where(m => m.ID == mid).FirstOrDefault());
            _context.SaveChanges();
            return View("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

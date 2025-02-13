using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Mission06_Beales.Models;

namespace Mission06_Beales.Controllers
{
    public class HomeController : Controller
    {
        private MovieCollectionContext _context;

        public HomeController(MovieCollectionContext temp) //constructor
        {
            _context = temp;
        }

        // home page
        public IActionResult Index()
        {
            return View();
        }
        // get to know Joel page
        public IActionResult GetToKnow()
        {
            return View();
        }

        // movie collection page
        [HttpGet]
        public IActionResult MovieCollection()
        {
            return View();
        }
        // submit a movie form
        [HttpPost]
        public IActionResult MovieCollection(Movie response ) // we are going to receive an instance of a Movie
        {
            _context.Movies.Add(response); // add record to the database
            _context.SaveChanges();

            return View("Confirmation", response);
        }

    }
}

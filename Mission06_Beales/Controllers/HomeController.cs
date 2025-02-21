using System.Diagnostics;
using System.Xml;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Mission06_Beales.Models;
using Microsoft.EntityFrameworkCore;

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

        // submit a movie page
        [HttpGet]
        public IActionResult MovieCollection ()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieCollection", new Movie());
        }


        // submit a movie form
        [HttpPost]
        public IActionResult MovieCollection(Movie response ) // we are going to receive an instance of a Movie
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // add record to the database
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View(response);
            }
        }


        public IActionResult MovieCollectionDisplay()
        {
            // Linq. SQLish language we use to pull data from the database in dotnet --------------------------------------------------------------------------------
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieCollection", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieCollectionDisplay");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .SingleOrDefault(x => x.MovieId == id);

            if (recordToDelete == null)
            {
                return NotFound();
            }

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie); // remove the record that was just passed in
            _context.SaveChanges();

            return RedirectToAction("MovieCollectionDisplay");
        }

    }
}

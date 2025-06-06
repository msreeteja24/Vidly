using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index(int? page, string sortBy)
        {
            #region Basic Example
            //if (!page.HasValue)
            //    page = 1;

            //if (sortBy.IsNullOrWhiteSpace())
            //    sortBy = "Name";

            ////return RedirectToAction("Index", "Home", new { page, sortBy });
            //return Content(String.Format("pageindex - {0}, sortBy - {1}", page, sortBy));
            ////In URL - this will work only using a query string. Will not work as URL Path - For URL path we need a custom path
            #endregion
            var movies = GetMovies();
            return View(movies);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{Id = 1, Name = "Charlie"},
                new Movie {Id = 2, Name = "Tourist Family"}
            };
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Nimo" };

            #region ActionResult methods and ViewData,ViewBag
            //return View(movie); // Helper method to render the view with the model.
            //return Content("Hello World!"); // Returns a simple string response.
            //return HttpNotFound(); // Returns a 404 Not Found response.
            //return new EmptyResult(); // Returns an empty response.
            //To redirect to another action
            //return RedirectToAction("Index", "Home"); // Redirects to the Index action of the Home controller.
            //We can also pass arguments to the target action by passing an anonymous object
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); // Redirects to the Index action of the Home controller with query parameters.

            //For ViewData
            /*ViewData["Movie"] = movie;
            return View();*/

            //For View Bag
            /*ViewBag.Movie = movie;
            return View();*/
            #endregion

            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"},
                new Customer{Name = "Customer 3"},
                new Customer{Name = "Customer 4"},

            };

            var viewModel = new RandomMovieViewModel() { Movie = movie, Customers = customers };

            return View(viewModel);


        }

        public ActionResult Edit(int id)
        {
            return Content("id: " + id);
        }

        //movies
        

        [Route("movies/releasedate/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
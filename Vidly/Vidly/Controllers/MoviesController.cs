using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                var viewModel = new MovieViewModel
                {
                    Genres = _context.Genres.ToList(),
                    Movie = new Movie() { Id = 0 }
                };
                return View("List", viewModel);
            }

            return View("ReadOnly");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create(int? id)
        {
            var Genretypes = _context.Genres.ToList();
            var viewModel = new MovieViewModel
            {
                Genres = Genretypes,
                Movie = new Movie() { Id = 0 }
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            String message = " Hello ";
            if (movie.Id == 0)
            {
                movie.DateAdded = System.DateTime.Now;
                _context.Movies.Add(movie);
                message = "Movie Added Successfull..";
            }
            else
            {
                var movieIndb = _context.Movies.Single(u => u.Id == movie.Id);
                movieIndb.GenreId = movie.GenreId;
                movieIndb.Name = movie.Name;
                movieIndb.ReleaseDate = movie.ReleaseDate;
                movieIndb.DateAdded = movie.DateAdded;
                movieIndb.NumberInStock = movie.NumberInStock;
                message = "Movies Details Update Successfull";
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.Message = " .. Errror... ";
                var viewmodel = new MovieViewModel
                {
                    Genres = _context.Genres.ToList(),
                    Movie = movie
                };
                return View("Create", viewmodel);
            }

            ViewBag.Message = message;
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Save_Modular(MovieViewModel movieModel)
        {
            if (movieModel.Movie.Name !=null) // || movieModel.Movie.NumberInStock == 0 || movieModel.Movie.GenreId==0))
            {
                ViewBag.Message = "Success";
                ModelState.Clear();
                var Genretypes = _context.Genres.ToList();
                var viewModel = new MovieViewModel
                {
                    Genres = Genretypes,
                    Movie = new Movie() { Id = 0 }
                };
                return View("List", viewModel);
            }
            else
            {
                ViewBag.Message = "Failed";
                var Genretypes = _context.Genres.ToList();
                var viewModel = new MovieViewModel
                {
                    Genres = Genretypes,
                    Movie = new Movie() { Id = 0 }
                };
                return View("List", movieModel);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) { return HttpNotFound(); }
            else
            {
                var movie = _context.Movies.Single(c => c.Id == id);
                if (movie == null)
                    return HttpNotFound();
                var viewmodel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("Create", viewmodel);
            }
        }

        public ActionResult Create_Jquery()
        {
            var Genretypes = _context.Genres.ToList();
            var viewModel = new MovieViewModel
            {
                Genres = Genretypes,
                Movie = new Movie() { Id = 0 }
            };
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Create_Post(Movie movie)
        {
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            int i = _context.SaveChanges();
            if (i == 1)
                return Json("true", JsonRequestBehavior.AllowGet);
            else
                return Json("false", JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetAllMoviesName(string term)
        {
            var Names = _context.Movies.Where(
                c => c.Name
                .StartsWith(term)).
                Select(c => c.Name)
                .ToList();

            return Json(Names, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsMovie_Name_used(string ProposedMovieName)
        {
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Dlte()
        {
            var viewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = new Movie() { Id = 0 }
            };
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = new Movie() { Id = 0 }
            };
            return View(viewModel);
        }
    }
}

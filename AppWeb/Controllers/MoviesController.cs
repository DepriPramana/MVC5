using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using AppWeb.Models;
using AppWeb.ViewModel;

namespace AppWeb.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _objDataModel;

        public MoviesController()
        {
            _objDataModel = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _objDataModel.Dispose();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movie = _objDataModel.Movies.Include(m =>m.Genre).ToList();
            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = _objDataModel.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        

        [Route("movies/random")]
        public ActionResult Random()
        {
            
            RandomMovieViewModel randomMovieViewModel = new RandomMovieViewModel()
            {
                Movies = _objDataModel.Movies.ToList(),
                Customers = _objDataModel.Customers.ToList()
            };
            return View(randomMovieViewModel);
        }
        
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month); 
        }

        public ActionResult New()
        {
            var movies = new MovieGenreViewModel()
            {
                Genres = _objDataModel.Genres.ToList()
            };

            return View("MovieForm", movies);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var returnMovie = new MovieGenreViewModel(movie)
                {
                    Genres = _objDataModel.Genres.ToList()
                };
                return View("MovieForm", returnMovie);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _objDataModel.Movies.Add(movie);
            }
            else
            {
                var dataInsert = _objDataModel.Movies.Single(m => m.Id == movie.Id);
                dataInsert.Name = movie.Name;
                dataInsert.GenreId = movie.GenreId;
                dataInsert.InStock = movie.InStock;
                dataInsert.ReleaseDate = movie.ReleaseDate;
            }

            _objDataModel.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _objDataModel.Movies.Single(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var movieViewModel = new MovieGenreViewModel(movie)
            {
                Genres = _objDataModel.Genres.ToList()
            };
            return View("MovieForm",movieViewModel);
        }
    }
}
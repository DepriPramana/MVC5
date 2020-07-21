using AppWeb.Dtos;
using AppWeb.Models;
using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace AppWeb.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public readonly ApplicationDbContext _objDbContext;

        public MoviesController()
        {
            _objDbContext = new ApplicationDbContext();
        }

        // GET /api/customers
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movie = _objDbContext.Movies
                .Include(m =>m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movie);
        }

        // GET 1 /api/customers/1
        [HttpGet]
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _objDbContext.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateMovies(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _objDbContext.Movies.Add(movie);
            _objDbContext.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateMovies(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _objDbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);


            _objDbContext.SaveChanges();

            return Ok(movieDto);

        }
        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomers(int id)
        {
            var movieInDb = _objDbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _objDbContext.Movies.Remove(movieInDb);

            _objDbContext.SaveChanges();

        }
    }
}

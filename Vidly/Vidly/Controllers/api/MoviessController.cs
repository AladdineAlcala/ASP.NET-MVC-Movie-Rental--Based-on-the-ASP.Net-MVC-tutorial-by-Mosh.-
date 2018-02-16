using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;
using System.Data.Entity;


namespace Vidly.Controllers.api
{
    public class MoviessController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviessController()
        {
            this._context = new ApplicationDbContext();
        }

        //get /api/moviess
        public IEnumerable<MovieDTO> GetMovie(string query=null)
        {
            var MoviesQuery = _context.Movies
                .Include(c => c.Genre)
                .Where(c=>c.NumberAvailable>0)
                ;

            if (!String.IsNullOrWhiteSpace(query))
                MoviesQuery = MoviesQuery.Where(
                    c=>c.Name.Contains(query));

            var MoviesDtos = MoviesQuery
                .ToList()
                .Select(Mapper.Map<Movie,MovieDTO>);

            return (MoviesDtos);
      //      return Ok(MoviesDtos);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies
                .Include(ch=>ch.Genre)
                .SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();
            //return BadRequest();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        //post /api/moviess
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movies = Mapper.Map<MovieDTO, Movie>(movieDTO);
                _context.Movies.Add(movies);
                _context.SaveChanges();
                movieDTO.Id = movies.Id;
                return Created(new Uri(Request.RequestUri + "/" + movies.Id), movieDTO);
        }

        //put /api/moviess/1
        [HttpPut]
        public void UpdateMovie(int id,MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(mo => mo.Id == id);

            if(movieInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            Mapper.Map(movieDTO, movieInDb);
            _context.SaveChanges();
        }

        //delete /api/moviess/1
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var moviesinDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            _context.Movies.Remove(moviesinDb);
            _context.SaveChanges();
        }

    }
}

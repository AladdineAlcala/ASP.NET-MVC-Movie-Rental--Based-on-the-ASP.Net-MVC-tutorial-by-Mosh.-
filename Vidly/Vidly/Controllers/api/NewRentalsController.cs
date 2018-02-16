using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            this._context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            var customer = _context.Customers.SingleOrDefault(
                  c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Customer not found");

            //select * from Movies Where Id In(1,2,3)
            var moviess = _context.Movies.Where(
                m=>newRental.MovieIds.Contains(m.Id)).ToList();

            if (!(moviess.Count == newRental.MovieIds.Count))
                return BadRequest("Unexpected Request 'Custom Message' db data and user request doesnot match");


            foreach(var movie in moviess)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental {
                    customer_rental = customer,
                    Movie_rental = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}

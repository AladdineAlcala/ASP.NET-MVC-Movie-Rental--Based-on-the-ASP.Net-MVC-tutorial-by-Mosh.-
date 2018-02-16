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
    public class CustomerssController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomerssController()
        {
            this._context = new ApplicationDbContext();
        }

        // Get/api/customerss
        public IEnumerable<CustomerDTO> GetCustomer(string query = null)
        {
            var CustomersQuery = _context.Customers
                .Include(c => c.MembershipType)
                ;

            if (!String.IsNullOrWhiteSpace(query))
                CustomersQuery = CustomersQuery.Where(
                    c => c.Name.Contains(query));

            var CustomersDtos = CustomersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

            return (CustomersDtos);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
            // return Ok(Mapper.Map<Customer,cus);
        }

        //post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
         
            var custoomer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(custoomer);
            _context.SaveChanges();

            customerDTO.Id = custoomer.Id;
            return Created(new Uri(Request.RequestUri + "/" + custoomer.Id), customerDTO);  //customerDTO;
        }

        //put /api/customerss/1
        [HttpPut]
        public void updateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerinDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

//            Mapper.Map<CustomerDTO, Customer>(customerDto, customerinDB);
            Mapper.Map(customerDto, customerinDB);

            _context.SaveChanges();
        }

        //delete /api/customerss/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerinDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            _context.Customers.Remove(customerinDB);
            _context.SaveChanges();
        }
    }
}

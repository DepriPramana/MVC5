using AppWeb.Models;
using AppWeb.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;

namespace AppWeb.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public readonly ApplicationDbContext _objDbContext;

        public CustomersController()
        {
            _objDbContext = new ApplicationDbContext();
        }

        // GET /api/customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _objDbContext.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customers, CustomersDto>);

            return Ok(customerDtos);
        }

        // GET 1 /api/customers/1
        [HttpGet]
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _objDbContext.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customers,CustomersDto>(customer));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomers(CustomersDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomersDto, Customers>(customerDto);
            _objDbContext.Customers.Add(customer);
            _objDbContext.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri +"/"+ customer.Id),customerDto);
        }
        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomers(int id, CustomersDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _objDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
         

            _objDbContext.SaveChanges();

            return Ok(customerDto);

        }
        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomers(int id)
        {
            var customerInDb = _objDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            _objDbContext.Customers.Remove(customerInDb);

            _objDbContext.SaveChanges();

        }

    }
}

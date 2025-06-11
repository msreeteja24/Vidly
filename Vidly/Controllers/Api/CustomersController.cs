using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers/
        #region The below is using Cutomer domain
        //public IEnumerable<Customer> GetCustomers()
        //{

        //    return _context.Customers.ToList();

        //}
        #endregion
        #region To get using a DTO
        //public IEnumerable<CustomerDto> GetCustomers()
        //{
        //    return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        //}
        #endregion
        //Using IHttpActionResult
        public IHttpActionResult GetCustomers()
        {
            var customersDto = _context.Customers.ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customersDto);
        }


        //GET /api/customers/1
        #region This is using Customer domain
        //public Customer GetCustomer(int id)
        //{

        //    var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
        //    if (customer == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    return customer;

        //}
        #endregion
        #region The below is with using CustomerDto
        //public CustomerDto GetCustomer(int id)
        //{
        //    var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
        //    if (customer == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return Mapper.Map<Customer, CustomerDto>(customer);
        //}
        #endregion
        //using IHtttpAction reslt
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        #region Using customer domain
        //We can also write as below without HttpPost attribute
        //public Customer PostCustomer(Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);


        //}
        //But always explicitly mark an action as post request
        //The below is with domain class
        //[HttpPost]
        //public Customer CreateCustomer(Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();

        //    return customer;
        #endregion
        #region Using CustomerDto
        //public CustomerDto CreateCustomer(CustomerDto customerDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    //To map back to customer domain 
        //    var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();

        //    customerDto.Id = customer.Id;

        //    return customerDto;
        //}
        #endregion
        //To create a class IHttpActtionResult
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //To map back to customer domain 
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT  /api/customers/1
        #region The below method is with Customer domain
        //[HttpPut]
        //public void UpdateCustomer(int id, Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        //    if (customerInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    customerInDb.Name = customer.Name;
        //    customerInDb.BirthDate = customer.BirthDate;
        //    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        //    customerInDb.MembershipTypeId = customer.MembershipTypeId;


        //    _context.SaveChanges();

        //}
        #endregion
        # region Below is with CstomerDto
        //[HttpPut]
        //public void UpdateCustomer(int id, CustomerDto customerDto)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        //    if (customerInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    Mapper.Map(customerDto, customerInDb);


        //    _context.SaveChanges();

        //}
        #endregion
        //Below is with IHttpActionResult
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);


            _context.SaveChanges();

            return Ok();

        }


        //Delete /api/customers/1
        #region without using IHttpActionResult
        //[HttpDelete]
        //public void DeleteCustomer(int id)
        //{
        //    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

        //    if (customerInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    _context.Customers.Remove(customerInDb);

        //    _context.SaveChanges();

        //}
        #endregion
        //Using IHttpActionResult
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerindb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerindb == null)
                return NotFound();

            _context.Customers.Remove(customerindb);

            _context.SaveChanges();

            return Ok();

        }
    }
}

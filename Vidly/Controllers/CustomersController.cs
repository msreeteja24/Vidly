using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //If you want to access the data from a database then we have to add the DbContext to access the database
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Since the DbContext is a disposable object we need to properly Dispose it.
        //For that we need to override the Dispose method of the Controller menthod.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers 
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            
            return View(customers);

        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            
            return View(customer);
        }

        //If we want to access the data by manually adding. 
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{ Id = 1, Name ="Sree Teja"},
        //        new Customer {Id =2 , Name ="Yamini"}
        //    };
            
        //}
    }
}
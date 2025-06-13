using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            //return View(customers);
            return View();

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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //This is the 2nd step for  validation - ModelState.Valid will change the flow of the application.
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    //We have to write the below in order to populate the form with the details already filled.
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);

            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb, "", "Name, BirthDate"); 
                //The above method from Controller class will update all properties which is not advisable so we use another method.
                //Even though we write propery names to change specific properties, they are magic string and that method access all properties from Database. 
                //This leads to security holes.

                //Second method
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                //Instead of writing all properties we can use Mapper method
                //Mapper.Map(customer,  customerInDb); 
                //Here we can add exceptions to update properties by creating DTO class and instead of Customer class we use DTO class in this action.

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
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
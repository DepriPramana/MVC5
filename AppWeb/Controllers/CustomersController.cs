using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AppWeb.Models;
using AppWeb.ViewModel;

namespace AppWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _objDataModel;
        protected override void Dispose(bool disposing)
        {
            _objDataModel.Dispose();
        }
        // GET: Customer
        public CustomersController()
        {
            _objDataModel = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
            var customers = _objDataModel.Customers.Include(c =>c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _objDataModel.MembershipTypes.ToList();
            var customerViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",customerViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                var returnCustomer = new CustomerFormViewModel(customers)
                {
                    MembershipTypes = _objDataModel.MembershipTypes.ToList()
                };
                return View("CustomerForm", returnCustomer);
            }
            if (customers.Id == 0)
            {
                _objDataModel.Customers.Add(customers);
            }
            else
            {
                var objCustomerUpdate = _objDataModel.Customers.Single(c => c.Id == customers.Id);
                objCustomerUpdate.Name = customers.Name;
                objCustomerUpdate.Birthdate = customers.Birthdate;
                objCustomerUpdate.IsSubscribedToNewsletter = customers.IsSubscribedToNewsletter;
                objCustomerUpdate.MembershipTypeId = customers.MembershipTypeId;

            }
            
            _objDataModel.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {
            var customer = _objDataModel.Customers.Include(c =>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _objDataModel.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _objDataModel.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}
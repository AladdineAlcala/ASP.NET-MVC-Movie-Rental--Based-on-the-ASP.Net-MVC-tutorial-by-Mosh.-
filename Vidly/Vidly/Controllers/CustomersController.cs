using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }

        public JsonResult Getall_Users_MemberType_Name()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return Json(customers,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var membershipTYpes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerViewModel
            {
                MembershipTypes = membershipTYpes,
                Customer = new Customer() { Id=0}
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            String message = " Hello ";
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                message = "Account Created Successfull..";
            }
            else
            {
                var usersIndb = _context.Customers.Single(u => u.Id == customer.Id);
                usersIndb.Name = customer.Name;
                usersIndb.IsSubscribedTONewsLetter = customer.IsSubscribedTONewsLetter;
                usersIndb.DateofBirth = customer.DateofBirth;
                usersIndb.MembershipTypeId = customer.MembershipTypeId;
                message = "Account Update Successfull";
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.Message = " .. Errror... ";
                var viewmodel = new CustomerViewModel
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    Customer = customer
                };
                return View("Create", viewmodel);
            }

            ViewBag.Message = message;
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) { return HttpNotFound(); }
            else
            {
                var user = _context.Customers.Single(c => c.Id == id);
                if (user == null)
                    return HttpNotFound();
                var viewmodel = new CustomerViewModel
                {
                    Customer = user,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("Create", viewmodel);
            }
        }


    }
}
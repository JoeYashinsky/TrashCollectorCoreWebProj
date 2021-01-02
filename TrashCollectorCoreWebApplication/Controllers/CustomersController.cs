using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorCoreWebApplication.Data;
using TrashCollectorCoreWebApplication.Models;

namespace TrashCollectorCoreWebApplication.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            //Access currently signed-in user. This line will return user's PK Id from AspNetUsers table. If not signed in, userId null.
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (customer == null)
            {
                return RedirectToAction("Create");  //if no Id found (not a customer yet), take to Create page
            }

            return View("Details", customer);  //If valid userId is found, direct this customer to his designated "Details" page
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (customer == null)
            {
                return NotFound();
            }
            
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            var days = _context.Days.ToList();
            Customer customer = new Customer()
            {
                Days = new SelectList(days, "Id", "Name")  //add unmapped (no column in table) SelectList Days property in Cust model to remove error
            };
            return View(customer);
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Days = new SelectList(_context.Days.ToList(), "Id", "Name");
            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            var loggedInCustomer = _context.Customers.SingleOrDefault(m => m.Id == id);
            loggedInCustomer.FirstName = customer.FirstName;
            loggedInCustomer.LastName = customer.LastName;
            loggedInCustomer.StreetAddress = customer.StreetAddress;
            loggedInCustomer.City = customer.City;
            loggedInCustomer.State = customer.State;
            loggedInCustomer.ZipCode = customer.ZipCode;
            loggedInCustomer.DayId = customer.DayId;
            loggedInCustomer.Days = new SelectList(_context.Days.ToList(), "Id", "Name");
            loggedInCustomer.ExtraPickupDate = customer.ExtraPickupDate;
            loggedInCustomer.SuspendServiceDate = customer.SuspendServiceDate;
            loggedInCustomer.SuspensionEndDate = customer.SuspensionEndDate;
            
            _context.SaveChanges();
            return RedirectToAction("Details", customer);
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(s => s.Id == id);
            return View(customer);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                var removedCustomer = _context.Customers.SingleOrDefault(m => m.Id == id);
                _context.Remove(removedCustomer);   
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

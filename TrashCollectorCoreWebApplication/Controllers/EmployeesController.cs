﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrashCollectorCoreWebApplication.Data;
using TrashCollectorCoreWebApplication.Models;
using TrashCollectorCoreWebApplication.Models.ViewModel;

namespace TrashCollectorCoreWebApplication.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            //Access currently signed-in user. This line will return user's PK Id from AspNetUsers table. If not signed in, userId null.
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            if (employee == null)
            {
                return RedirectToAction("Create");  //if no Id found (not an employee yet), take to Create page
            }

            //Need to filter Customers list to present this Employee with specific pickups scheduled for this day and in employee route zip
            var customerList = _context.Customers.Include(c => c.Day).ToList();
            var routeZipCodeCustomers = customerList.Where(c => c.ZipCode == employee.RouteZipCode).ToList();
            var currentDay = DateTime.Today.DayOfWeek.ToString();
            var regularPickupCustomers = routeZipCodeCustomers.Where(c => c.Day.Name == currentDay).ToList();
            //Need to also account for one-time (extra) pickups or possible suspensions of service
            var extraCustomers = routeZipCodeCustomers.Where(c => c.ExtraPickupDate == DateTime.Today).ToList();
            var allCustomersPreSuspension = regularPickupCustomers.Concat(extraCustomers);        //var newList = a.Concat(b);
            //var allCustomersToday = allCustomersPreSuspension.Where(c => c.SuspendServiceDate! <= DateTime.Today && c.SuspensionEndDate! >= DateTime.Today).ToList();
            var allCustomersToday = allCustomersPreSuspension.Where(c => c.SuspendServiceDate == null ? true : (c.SuspendServiceDate > DateTime.Today && c.SuspensionEndDate < DateTime.Today)).ToList();


            return View("Index", allCustomersToday);
        }

        // POST: EmployeesController (FilterByDay)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterByDay(string pickupsForThisDay)
        {
            DayOfWeekCustomers dayOfWeekCustomers = new DayOfWeekCustomers();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            var routeZipCodeCustomers = _context.Customers.Where(c => c.ZipCode == employee.RouteZipCode).ToList();
            var filteredCustomers = routeZipCodeCustomers.Where(c => c.Day.Name == pickupsForThisDay).ToList();

            return View(filteredCustomers);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            //var employee = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Employee employee)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault(); if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            var loggedInEmployee = _context.Employees.SingleOrDefault(m => m.Id == id);
            loggedInEmployee.FirstName = employee.FirstName;
            loggedInEmployee.LastName = employee.LastName;
            loggedInEmployee.RouteZipCode = employee.RouteZipCode;


            _context.SaveChanges();
            return View(employee);
        }

        //public bool PickupConfirmed { get; set; }  (property in Customer model)
        public ActionResult DriverConfirms(int id)  //need to confirm that a Customer's trash was picked up, then apply charge to that Customer
        {
            var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            if(customer.PickupConfirmed == true)
            {
                customer.BalanceDue += 15.00;
                _context.Update(customer);
                _context.SaveChanges();
            }
            else
            {
                customer.BalanceDue = 0.00;
            }
            return View(customer);

            
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int? id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var removedEmployee = _context.Customers.SingleOrDefault(c => c.Id == id);
                _context.Remove(removedEmployee);
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

using DBFirst.Models;
using DBFirst.services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirst.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService customerService;

        public CustomerController()
        {
            this.customerService = new CustomerServiceImpl(new DBFirstTestEntities());
        }
        // GET: Customer
        public ActionResult Index()
        {
            var list = customerService.getCustomers().ToList();
            return View(list);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customerObj = customerService.getCustomerId(id);

            var customer = new Customer();

            customer.Id = id;

            customer.Fname = customerObj.Fname;

            customer.Lname = customerObj.Lname;


            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View(new Customer());
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Customer customerObj)
        {
            try

            {

                var customer = new Customer();

                Debug.WriteLine("test");
                
                customer.Fname = customerObj.Fname;

                customer.Lname = customerObj.Lname;


                customerService.InsertCustomer(customer); // Passing data to customerService 

                return RedirectToAction("Index");

            }

            catch

            {

                return View();

            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = customerService.getCustomerId(id); // getting records by 

            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection, Customer customer)
        {
            try

            {


                customerService.updateCustomer(customer); // calling UpdateEmployee method of EmployeeRepository

                return RedirectToAction("Index");

            }

            catch

            {

                return View();

            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = customerService.getCustomerId(id); // getting records by 

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                customerService.deleteCustomer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

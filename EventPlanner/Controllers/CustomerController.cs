using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using EventPlanner.Services;

namespace EventPlanner.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var service = CreateCustomerService();
            var model = service.GetCustomers();
            return View(model);
        }

        //Get: Customer/Detail/{id}
        public ActionResult Details(int id)
        {
            var service = CreateCustomerService();
            var model = service.GetCustomerById(id);

            return View(model);
        }
        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer was successfully created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Customer could not be created.");

            return View(model);
        }


        //Get: Customer/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model
                = new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    CustomerFName = detail.CustomerFName,
                    CustomerLName = detail.CustomerLName,
                    CustomerMInitial = detail.CustomerMInitial,
                    Address = detail.Address,
                    City = detail.City,
                    State = detail.State

                };
            return View(model);
        }

        //Get: post Customer/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "id Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.EditCustomer(model))
            {
                TempData["SaveResult"] = "The customer was successfully updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The customer could not be updated.");
            return View(model);
        }

        //Get: Delete/Customer/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateCustomerService();
            var model = service.GetCustomerById(id);

            return View(model);
        }

        //Get: Post Delete/Customer/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);
            
            TempData["SaveResult"] = "The customer was successfully deleted.";

            return RedirectToAction("index");
          
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new CustomerService(userId);

        }
    }
}
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace EventPlanner.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var model = new CustomerListItem[0];
            return View(model);
        }
    }
}
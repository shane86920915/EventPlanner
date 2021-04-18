using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Controllers
{
    public class CustomerEventController : Controller
    {
        // GET: CustomerEvent
        public ActionResult Index()
        {
            return View();
        }
    }
}
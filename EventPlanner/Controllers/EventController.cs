using EventPlanner.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            var service = CreateEventServices();
            var model = service.GetEvent();
            return View(model);
        }

        public EventService CreateEventServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new EventService(userId);
        }

    }
}
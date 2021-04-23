using EventPlanner.Models;
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
            var service = CreateEventService();
            var model = service.GetEvent();
            return View(model);
        }

        //Get: Event/Detail/{id}
        public ActionResult Detail(int id)
        {
            var service = CreateEventService();
            var model = service.GetEventById(id);
            return View(model);


        }

        //Get: Create/Event
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Event was successfully created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("","Event could not be created.");

            return View(model);
        }

        //Post: Create/Event
        public EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new EventService(userId);
        }

        //Get: 

    }
}
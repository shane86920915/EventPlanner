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

        //Post: Create/Event
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

        //Get: Event/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(id);
            var model
                    = new EventEdit
                    {
                        EventId = detail.EventId,
                        EventTitle = detail.EventTitle,
                        Price = detail.Price,
                        Address = detail.Address,
                        City = detail.City,
                        State = detail.State
                    };
            return View(model);
        }

        //Post: Event/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if(model.EventId != id)
            {
                ModelState.AddModelError("", "id Mismatch");
                return View(model);
            }

            var service = CreateEventService();

            if (service.EditEvent(model))
            {
                TempData["SaveResult"] = "The event was successfully Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The event could not be updated");
            return View(model);

          
        }
        public EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new EventService(userId);
        }

        //Get: 

    }
}
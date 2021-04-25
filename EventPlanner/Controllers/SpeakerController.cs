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
    public class SpeakerController : Controller
    {
        // GET: Speaker
        public ActionResult Index()
        {
            var service = CreateSpeakerService();
            var model = service.GetSpeaker();
            return View(model);
        }

        //Get: Speaker/Details/{id}
        public ActionResult GetDetails(int id)
        {
            var service = CreateSpeakerService();
            var model = service.GetSpeakerById(id);
            return View(model);
        }

        //Get: Create/Speaker
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create/Speaker
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpeakerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSpeakerService();

            if (service.CreateSpeaker(model))
            {
                TempData["SaveResult"] = "Speaker was successfully created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Speaker could not be created");
            return View(model);
        }

        public SpeakerService CreateSpeakerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new SpeakerService(userId);
        }
    }
}
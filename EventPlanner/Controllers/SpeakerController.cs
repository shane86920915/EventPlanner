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
        public ActionResult Details(int id)
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

        //Get: Speaker/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateSpeakerService();
            var details = service.GetSpeakerById(id);
            var model
                = new SpeakerEdit
                {
                    SpeakerId = details.SpeakerId,
                    SpeakerFName = details.SpeakerFName,
                    SpeakerLName = details.SpeakerLName,
                    State = details.State,
                    Address = details.Address,
                    City = details.City
                };
            return View(model);
        }

        // Post: Speaker/Edit/{id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SpeakerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSpeakerService();

            if(model.SpeakerId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
            }

            if (service.EditSpeaker(model))
            {
                TempData["SaveResult"] = "Speaker was successfully updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Speaker could not be updated");
            return View(model);

        }
        //Get: Speaker/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateSpeakerService();
            var model = service.GetSpeakerById(id);

            return View(model);
        }

        //Get: Speaker/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSpeakerService();

            service.DeleteSpeaker(id);

            TempData["SaveResult"] = "Speaker was succesfully deleted";

            return RedirectToAction("Index");
        }
        public SpeakerService CreateSpeakerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new SpeakerService(userId);
        }

    }
}

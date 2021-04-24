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

        public ActionResult 

        public SpeakerService CreateSpeakerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new SpeakerService(userId);
        }
    }
}
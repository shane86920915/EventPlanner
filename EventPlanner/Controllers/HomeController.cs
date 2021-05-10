using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            // extract only the fielname            
            var imageName = Path.GetFileName(file.FileName);
            var imgsrc = Path.Combine(Server.MapPath("~/images/"), imageName);
            string filepathToSave = "images/" + imageName;
            file.SaveAs(imgsrc);
            ViewBag.ImagPath = filepathToSave;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
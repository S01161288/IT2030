using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    public class HomeController : Controller
    {
        EventApplicationDB db = new EventApplicationDB();
        public ActionResult Index()
        {
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
        [HttpGet]
        public ActionResult LastMinuteDeals()
        {
            DateTime lastMinuteTime = DateTime.Now.AddDays(2);

            List<Event> lastMinuteDeals = db.Events.Where(e => DbFunctions.TruncateTime(e.StartDateTime) == lastMinuteTime.Date).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_LastMinuteDeals", lastMinuteDeals);
            }

            return PartialView(lastMinuteDeals);
        }

        [HttpGet]
        public ActionResult FindEvent(string eventKey, string locationKey)
        {
            return RedirectToRoute("Index", "Event");
        }


    }
}
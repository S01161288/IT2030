using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    public class EventController : Controller
    {
        
            EventApplicationDB db = new EventApplicationDB();

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["CurrentUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        #region Organize Event
        public ActionResult OrganizeEvent()
        {
            if (Session["CurrentUser"] != null)
            {
                EventType eventType = new EventType();
                ViewBag.EventTypeList = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName",
                    eventType.EventTypeID).OrderBy(a => a.Text);

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public ActionResult CreateEvent(Event newEvent)
        {
            db.Events.Add(newEvent);
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
        public ActionResult EventList()
        {
            return View(db.Events.ToList());
        }
        public ActionResult DeleteEvent(int id)
        {
            var deleteEvent = db.Events.FirstOrDefault(et => et.EventID == id);
            db.Events.Remove(deleteEvent);
            db.SaveChanges();
            return RedirectToAction("EventList");
        }

        public ActionResult EditEventDetail(int id)
        {
            EventType eventType = new EventType();
            ViewBag.EventTypeList = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName",
            eventType.EventTypeID).OrderBy(a => a.Text);
            Event item = db.Events.FirstOrDefault(tc => tc.EventID == id);
            return View(item);
        }

        public ActionResult EditEvent(Event editEvent)
        {
            db.Entry(editEvent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EventList");
        }

        #endregion

        #region Event Types

        public ActionResult EventType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEventType(EventType newEventType)
        {
            db.EventTypes.Add(newEventType);
            db.SaveChanges();
            return RedirectToAction("EventTypeList");
        }

        public ActionResult DeleteEventType(int id)
        {
            var deleteEventType = db.EventTypes.FirstOrDefault(et => et.EventTypeID == id);
            db.EventTypes.Remove(deleteEventType);
            db.SaveChanges();
            return RedirectToAction("EventTypeList");
        }

        public ActionResult EditEventTypeDetail(int id)
        {
            EventType item = db.EventTypes.FirstOrDefault(tc => tc.EventTypeID == id);
            return View(item);
        }

        public ActionResult EditEventType(EventType editEventType)
        {
            db.Entry(editEventType).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EventTypeList");
        }
        public ActionResult EventTypeList()
        {
            return View(db.EventTypes.ToList());
        }
        #endregion
        #region Find Event
        [HttpGet]
        public ActionResult FindEvent(string eventKey, string locationKey)
        {
            if (Session["CurrentUser"] != null)
            {
                List<Event> eventsModel = db.Events.Where(e => (e.Title.Contains(eventKey) || e.EventType.EventTypeName.Contains(eventKey) || e.City.Contains(locationKey) || e.State.Contains(locationKey))).ToList();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_FindEvent", eventsModel);
                }

                return PartialView(eventsModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpGet]
        public ActionResult EventDetail(int id)
        {
            var eventModel = db.Events.FirstOrDefault(e => e.EventID == id);
            return View(eventModel);
        }

        [HttpGet]
        public ActionResult RegisterEvent(int id)
        {
            var eventModel = db.Events.FirstOrDefault(e => e.EventID == id);
            return View(eventModel);
        }

        public ActionResult OrderSummary()
        {
            EventApplicationDB dbContext = new EventApplicationDB();
            List<TicketOrder> orderSummary = dbContext.TicketOrders.ToList();

            return View(orderSummary);
        }
        #endregion
    }
}
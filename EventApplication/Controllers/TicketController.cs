using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    public class TicketController : Controller
    {
            
        EventApplicationDB db = new EventApplicationDB();

        public ActionResult Index()
        {
            List<TicketOrder> ticketOrders = db.TicketOrders.ToList();
            foreach (var ticket in ticketOrders)
            {
                ticket.Event = db.Events.FirstOrDefault(e => e.EventID == ticket.EventID);
                ticket.User = db.Users.FirstOrDefault(e => e.UserID == ticket.UserID);
            }

            return View(ticketOrders);
        }

        [HttpPost]
        public ActionResult Checkout(Event registeredEvent)
        {
            var selectedEvent = db.Events.FirstOrDefault(e => e.EventID == registeredEvent.EventID);
            TicketOrder order = new TicketOrder();
            order.NumberOfTicket = registeredEvent.AvailableTickets;
            order.EventID = registeredEvent.EventID;
            
            order.UserID = (Session["CurrentUser"] as User).UserID;
            order.Status = "Processed";
            db.TicketOrders.Add(order);
            db.SaveChanges();
            return View(order);
        }

        public ActionResult Cancel(int id)
        {
            var userId = (Session["CurrentUser"] as User).UserID;
            TicketOrder item = db.TicketOrders.FirstOrDefault(tc => tc.OrderNumber == id && tc.UserID == userId);
            item.Status = "Cancelled";

            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult OrderDetail(int id)
        {
            var ticketOrderModel = db.TicketOrders.FirstOrDefault(e => e.OrderNumber == id);
            ticketOrderModel.Event = db.Events.FirstOrDefault(e => e.EventID == ticketOrderModel.EventID);
            ticketOrderModel.User = db.Users.FirstOrDefault(e => e.UserID == ticketOrderModel.UserID);
            return View(ticketOrderModel);
        }

    }
}
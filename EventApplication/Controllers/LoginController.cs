using EventApplication.Models;
using System.Linq;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    public class LoginController : Controller
    {
        EventApplicationDB db = new EventApplicationDB();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(User user)
        {
            var loginUser = db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            if (loginUser != null)
            {
                Session["CurrentUser"] = loginUser;
                Session["CurrentEmail"] = loginUser.Email;
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["CurrentUser"] = null;
            Session["CurrentEmail"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}
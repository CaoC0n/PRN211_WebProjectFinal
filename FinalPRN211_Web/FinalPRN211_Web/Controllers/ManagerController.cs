using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using FinalPRN211_Web.Models;

namespace FinalPRN211_Web.Controllers
{
    public class ManagerController : Controller
    {
        TravelReviewContext _context = new TravelReviewContext();
        public string Mess {  get; set; }

        public IActionResult ManagerAccount()
        {
            User u = FinalPRN211_Web.Models.SessionExtensions.GetObject<User>(HttpContext.Session, "user");
            if (u == null || u.Role != 0)
            {
                return Redirect("/AccessDenied");
            }
            List<User> users = _context.Users.ToList();
            ViewBag.User = users;
            return View();
        }

        [HttpPost]
        public IActionResult ManagerAccount(int userId, int role, int status)
        {
            var u = HttpContext.Session.GetObject<User>("UserObject");
            List<User> users = _context.Users.ToList();
            User uedit = _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
            uedit.Status = status;
            uedit.Role = role;
            _context.SaveChanges();
            Mess = "Update successfully!";
            ViewBag.Mess = Mess;
            users = _context.Users.ToList();
            ViewBag.User = users;
            return View();
        }

    }
}


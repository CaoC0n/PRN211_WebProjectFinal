using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Xml.Linq;

namespace FinalPRN211_Web.Controllers 
{
    public class AuthenticationController : Controller
    {
        private BusinessLogic.UserBusinessLogic userBusinessLogic = new UserBusinessLogic();
        private TravelReviewContext context = new TravelReviewContext();

        public string Mess { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            Mess = "";
            ViewBag.Mess = Mess;
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(String username, String password)
        {
            User u = context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
            if (u != null && u.Status == 1)
            {
                Mess = "Account has been banned!";
                ViewBag.Mess = Mess;
                return View();
            }
            if (u != null)
            {
                FinalPRN211_Web.Models.SessionExtensions.SetObject(HttpContext.Session, "user", u);
                if (u.Role == 0)
                {
                    ViewBag.Mess = "";
                    return Redirect("/Manager/ManagerAccount");
                }
                else
                {
                    ViewBag.Mess = "";
                    return Redirect("/Home");
                }
            }
            else
            {
                Mess = "Username or Password not Correct!";
                ViewBag.Mess = Mess;
                return View();
            }
        }

        [HttpPost]
        public IActionResult SignUp(string firstname, string lastname, string username, string email, string password, string re_password)
        {
            var existingUsername = context.Users.FirstOrDefault(u => u.Username == username);
            var existingEmail = context.Users.FirstOrDefault(u => u.Email == email);
            if (existingUsername != null && existingEmail != null) 
            {
                ViewBag.Username = existingUsername.Username;
                ViewBag.Email = existingEmail.Email;
                ViewBag.Firstname = firstname;
                ViewBag.Lastname = lastname;
                ViewBag.MessUsername = "Username already exists.";
                ViewBag.MessEmail = "Email already exists.";
                return View();
            }

            try
            {
                userBusinessLogic.CreateUser(firstname, lastname, username, email, password);
                return Redirect("/Authentication/SignIn");
            }
            catch (Exception ex)
            {
                Mess = ex.Message;
                ViewBag.Mess = Mess;
                return View();
            }

        }
        public IActionResult Logout()
        {
            FinalPRN211_Web.Models.SessionExtensions.SetObject(HttpContext.Session, "user", null);
            return Redirect("/Home");
        }
    }
}


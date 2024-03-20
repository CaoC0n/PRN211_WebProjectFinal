using BusinessLogic;
using DataAccess.Models;
using FinalPRN211_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;

namespace FinalPRN211_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BusinessLogic.UserBusinessLogic userBusinessLogic = new UserBusinessLogic();
        private TravelReviewContext context = new TravelReviewContext();
        public string Mess { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Address> a = context.Addresses.ToList();
            ViewBag.Address = a;
            List<Food> f = context.Foods.ToList();
            ViewBag.Food = f;
            return View();
        }

        public IActionResult Profile()
        {
            User u = FinalPRN211_Web.Models.SessionExtensions.GetObject<User>(HttpContext.Session, "user");
            ViewBag.User = u;
            return View();
        }

        [HttpPost]
        public IActionResult Profile(int userId, string firstname, string lastname, string email, int gender, string phone)
        {
            try
            {
                userBusinessLogic.UpdateUser(userId, firstname.Trim(), lastname.Trim(), email, phone, gender);
                FinalPRN211_Web.Models.SessionExtensions.SetObject(HttpContext.Session, "user", context.Users.FirstOrDefault(u => u.UserId == userId));
                return Redirect("/Home/Profile");
            }
            catch (Exception ex)
            {
                Mess = ex.Message;
                ViewBag.Mess = Mess;
                return View();
            }
        }

        public IActionResult Changepass()
        {
            User u = FinalPRN211_Web.Models.SessionExtensions.GetObject<User>(HttpContext.Session, "user");
            ViewBag.User = u;
            return View();
        }

        [HttpPost]
        public IActionResult Changepass(int userId, string oldpassword, string newpassword)
        {
            try
            {
                User u = FinalPRN211_Web.Models.SessionExtensions.GetObject<User>(HttpContext.Session, "user");
                ViewBag.User = u;
                userBusinessLogic.changePassword(userId, oldpassword, newpassword);
                FinalPRN211_Web.Models.SessionExtensions.SetObject(HttpContext.Session, "user", null);
                return Redirect("/Home");
            }
            catch (Exception ex)
            {
                Mess = ex.Message;
                ViewBag.Mess = Mess;
                return View();
            }
        }

        public IActionResult Travel()
        {
            List<Address> a = context.Addresses.ToList();
            ViewBag.Travel = a;
            return View();
        }

        [HttpGet]
        [Route("Home/Travel")]
        public IActionResult Travel(string search)
        {
            List<Address> addresses = context.Addresses.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                addresses = addresses.Where(a => a.LocationName.Contains(search)).ToList();
            }

            ViewBag.Search = search;
            ViewBag.Travel = addresses;
            return View();
        }

        public Address address { get; set; }

        public IActionResult TravelDetail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            address = context.Addresses.FirstOrDefault(a => a.LocationId == id);

            if (address == null)
            {
                return NotFound();
            }

            List<Review> r = context.Reviews
                            .Include(r => r.User)
                            .Where(l => l.LocationId == id)
                            .ToList();
            ViewBag.Review = r;
            int numberOfComments = r.Count;
            ViewBag.NumberOfComments = numberOfComments;
            ViewBag.Address = address;
            return View();
        }

        [HttpPost]
        public IActionResult TravelDetail(int userId, int locationId, string description)
        {
            try
            {
                userBusinessLogic.createReview(userId, locationId, description);
                ViewBag.Mess = "Thank you for your comment!";
            }
            catch (Exception ex)
            {
                Mess = ex.Message;
                ViewBag.Mess = Mess;
            }
            address = context.Addresses.FirstOrDefault(a => a.LocationId == locationId);

            if (address == null)
            {
                return NotFound();
            }
            ViewBag.Address = address;
            return RedirectToAction("TravelDetail", "Home", new { id = locationId });
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult FoodReview()
        {
            List<Food> food = context.Foods.ToList();
            ViewBag.Food = food;
            return View();
        }

        [HttpGet]
        [Route("Home/FoodReview")]
        public IActionResult FoodReview(string search)
        {
            List<Food> food = context.Foods.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                food = food.Where(a => a.Name.Contains(search)).ToList();
            }

            ViewBag.Search = search;
            ViewBag.Food = food;
            return View();
        }

        public Food food { get; set; }

        public IActionResult FoodDetail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            food = context.Foods.FirstOrDefault(a => a.FoodId == id);

            if (food == null)
            {
                return NotFound();
            }
            ViewBag.Food = food;
            return View();
        }


    }
}

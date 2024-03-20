using Microsoft.AspNetCore.Mvc;

namespace FinalPRN211_Web.Controllers
{
    public class AccessDenied : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

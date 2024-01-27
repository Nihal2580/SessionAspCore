using Microsoft.AspNetCore.Mvc;
using SessionAspCore.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace SessionAspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        

        public IActionResult Index()
        {
            HttpContext.Session.SetString("key", "Programer");
            return View();
        }
        public IActionResult About()
        {
            if(HttpContext.Session.GetString("key") !=null)
            {
                ViewBag.Data = HttpContext.Session.GetString("key").ToString();
            }
            return View();
        }

        public IActionResult Detail()
        {
            if (HttpContext.Session.GetString("key") != null)
            {
                ViewBag.Data = HttpContext.Session.GetString("key").ToString();
            }
            return View();
        }

        public IActionResult LogOut()
        {
            if (HttpContext.Session.GetString("Mykey") != null)
            {
                HttpContext.Session.Remove("MyKey");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

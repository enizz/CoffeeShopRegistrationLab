using CoffeeShopRegistrationLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeeShopRegistrationLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CoffeeShopRegistrationLabContext context = new CoffeeShopRegistrationLabContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult AddUserToDb(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("GetUser", user);
        }

        public IActionResult GetUser()
        {
            List<User> users = context.Users.ToList();
            return View(users);
        }
        
    }
}
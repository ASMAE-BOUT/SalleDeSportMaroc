using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalleDeSportMaroc.Models;

namespace SalleDeSportMaroc.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        //[AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnvoyerMessage(string Nom, string Email, string Message)
        {
            TempData["Success"] = "Votre message a bien été envoyé. Nous vous répondrons bientôt !";
            return RedirectToAction("Contact");
        }

    }
}

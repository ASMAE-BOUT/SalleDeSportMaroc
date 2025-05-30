using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalleDeSportMaroc.Data;
using SalleDeSportMaroc.Models;
using System.Data;
using System.Linq;

namespace SalleDeSportMaroc.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [AllowAnonymous]
    public class CoursController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        public IActionResult Reservation()
        {
            return View();
        }
    }
}

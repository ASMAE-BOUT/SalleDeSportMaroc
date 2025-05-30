using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalleDeSportMaroc.Data;
using SalleDeSportMaroc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SalleDeSportMaroc.Controllers
{
    /*[Authorize] */// Empêche l'accès aux utilisateurs non connectés

    [Authorize(Roles = "Admin,User")]
    [AllowAnonymous]
    public class AbonnementController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;

        //public AbonnementController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        //{
        //    _context = context;
        //    _userManager = userManager;
        //}

        //// GET: Abonnement
        //public async Task<IActionResult> Index()
        //{
        //    var userId = _userManager.GetUserId(User);
        //    var abonnements = await _context.Abonnements
        //        .Where(a => a.UtilisateurId == userId)
        //        .ToListAsync();
        //    return View(abonnements);
        //}

        //// GET: Abonnement/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Abonnement/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Abonnement abonnement)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        abonnement.UtilisateurId = _userManager.GetUserId(User);
        //        _context.Add(abonnement);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(abonnement);
        //}


        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FormulaireAbonnement(string type)
        {
            ViewBag.TypeAbonnement = type;
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmerAbonnement(string TypeAbonnement, string Nom, string Email, string Telephone)
        {
            ViewBag.Message = $"Merci {Nom}, votre abonnement {TypeAbonnement} est bien pris en compte. Vous recevrez un email à {Email}.";
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Abonnement abonnement)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(abonnement);
        }

    }
}

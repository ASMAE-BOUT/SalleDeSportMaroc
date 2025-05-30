using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalleDeSportMaroc.Data;
using SalleDeSportMaroc.Models;
using System.Linq;

namespace SalleDeSportMaroc.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [AllowAnonymous]
    public class CoachController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoachController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            var coaches = _context.Coachs.ToList();
            return View(coaches);
        }

        public IActionResult Details(int id)
        {
            var coach = _context.Coachs.FirstOrDefault(c => c.Id == id);
            if (coach == null) return NotFound();

            return View(coach);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Coachs.Add(coach);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        public IActionResult Edit(int id)
        {
            var coach = _context.Coachs.Find(id);
            if (coach == null) return NotFound();

            return View(coach);
        }

        [HttpPost]
        public IActionResult Edit(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Coachs.Update(coach);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        public IActionResult Delete(int id)
        {
            var coach = _context.Coachs.Find(id);
            if (coach == null) return NotFound();

            return View(coach);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var coach = _context.Coachs.Find(id);
            if (coach == null) return NotFound();

            _context.Coachs.Remove(coach);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

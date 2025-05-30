using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalleDeSportMaroc.Data;
using SalleDeSportMaroc.Models;

namespace SalleDeSportMaroc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous] // Accessible à tous
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View("Index");
            }
            return RedirectToAction("RegisterAdmin");
        }

        [AllowAnonymous] // Accessible à tous
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [AllowAnonymous] // Accessible à tous
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        // Gérer les Séances
        public IActionResult ManageSessions()
        {
            var sessions = _context.Sessions.ToList();
            return View(sessions);
        }

        [HttpGet]
        public IActionResult CreateSession()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSession(Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Sessions.Add(session);
                _context.SaveChanges();
                return RedirectToAction("ManageSessions");
            }
            return View(session);
        }


        [HttpGet]
        public IActionResult EditSession(int id)
        {
            var session = _context.Sessions.Find(id);
            if (session == null) return NotFound();

            var model = new EditSessionViewModel
            {
                Id = session.Id,
                Activity = session.Activity,
                Date = session.Date,
                Time = session.Time,
                Coach = session.Coach
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditSession(EditSessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var session = _context.Sessions.Find(model.Id);
                if (session == null) return NotFound();

                session.Activity = model.Activity;
                session.Date = model.Date;
                session.Time = model.Time;
                session.Coach = model.Coach;

                _context.Update(session);
                _context.SaveChanges();

                return RedirectToAction("ManageSessions");
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult DeleteSession(int id)
        {
            var session = _context.Sessions.Find(id);
            if (session == null) return NotFound();

            _context.Sessions.Remove(session);
            _context.SaveChanges();

            return RedirectToAction("ManageSessions");
        }






        // Gérer les Membres
        public IActionResult ManageMembers()
        {
            var members = _context.Users.ToList();
            return View(members);
        }

        // Gérer les Absences
        public IActionResult ManageAbsences()
        {
            var absences = _context.Absences.ToList();
            return View(absences);
        }

        [HttpGet]
        public IActionResult CreateAbsence()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbsence(Absence absence)
        {
            if (ModelState.IsValid)
            {
                _context.Absences.Add(absence);
                _context.SaveChanges();
                return RedirectToAction("ManageAbsences");
            }
            return View(absence);
        }




        [HttpGet]
        public IActionResult CreateMember()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(RegisterAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User"); 
                    return RedirectToAction("ManageMembers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> EditMember(string id)
        {
            if (id == null) return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var model = new EditMemberViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMember(EditMemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null) return NotFound();

                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ManageMembers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> DeleteMember(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("ManageMembers");
            }

            return BadRequest("Erreur lors de la suppression du membre.");
        }





        //[HttpGet]
        //public IActionResult EditAbsence(int id)
        //{
        //    var absence = _context.Absences.Find(id);
        //    if (absence == null) return NotFound();

        //    var model = new EditAbsenceViewModel
        //    {
        //        Id = absence.Id,
        //        Name = absence.Name,
        //        Type = absence.Type,
        //        Date = absence.Date,
        //        Reason = absence.Reason
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult EditAbsence(EditAbsenceViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var absence = _context.Absences.Find(model.Id);
        //        if (absence == null) return NotFound();

        //        absence.Name = model.Name;
        //        absence.Type = model.Type;
        //        absence.Date = model.Date;
        //        absence.Reason = model.Reason;

        //        _context.Update(absence);
        //        _context.SaveChanges();

        //        return RedirectToAction("ManageAbsences");
        //    }

        //    return View(model);
        //}



        [HttpGet]
        public IActionResult EditAbsence(int id)
        {
            var absence = _context.Absences.Find(id);
            if (absence == null) return NotFound();

            var model = new EditAbsenceViewModel
            {
                Id = absence.Id,
                Name = absence.Name,
                Type = absence.Type,
                Date = absence.Date,
                Reason = absence.Reason
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditAbsence(EditAbsenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var absence = _context.Absences.Find(model.Id);
                if (absence == null) return NotFound();

                absence.Name = model.Name;
                absence.Type = model.Type;
                absence.Date = model.Date;
                absence.Reason = model.Reason;

                _context.Update(absence);
                _context.SaveChanges();

                return RedirectToAction("ManageAbsences");
            }

            return View(model);
        }




    }

    public class RegisterAdminViewModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }

    public class EditMemberViewModel
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }

    public class EditAbsenceViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
    }



    public class EditSessionViewModel
    {
        public int Id { get; set; }
        public string? Activity { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Coach { get; set; }
    }



}
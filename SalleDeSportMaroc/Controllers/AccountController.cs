using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalleDeSportMaroc.Models;

[Authorize]
public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Profil()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login");
        }

        ViewData["UserId"] = user.Id;
        ViewData["Abonnement"] = "Mensuel"; 

        return View();
    }

    public IActionResult RedirectToProfile()
    {
        return RedirectToAction("Profil", "Account");
    }

}

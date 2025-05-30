// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SalleDeSportMaroc.Models;

namespace SalleDeSportMaroc.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
            ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Mot de passe actuel")]
            public string OldPassword { get; set; }

            /// <summary>
            ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
            ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "Le {0} doit contenir au moins {2} et au maximum {1} caractères.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nouveau mot de passe")]
            public string NewPassword { get; set; }

            /// <summary>
            ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
            ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirmer le nouveau mot de passe")]
            [Compare("NewPassword", ErrorMessage = "Le nouveau mot de passe et sa confirmation ne correspondent pas.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("L'utilisateur a changé son mot de passe avec succès.");
            StatusMessage = "Votre mot de passe a été modifié.";

            return RedirectToPage();
        }
    }
}
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SalleDeSportMaroc.Models;

namespace SalleDeSportMaroc.Areas.Identity.Pages.Account.Manage
{
    public class TwoFactorAuthenticationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<TwoFactorAuthenticationModel> _logger;

        public TwoFactorAuthenticationModel(
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<TwoFactorAuthenticationModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public bool HasAuthenticator { get; set; }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public int RecoveryCodesLeft { get; set; }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        [BindProperty]
        public bool Is2faEnabled { get; set; }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public bool IsMachineRemembered { get; set; }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            HasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(user) != null;
            Is2faEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            IsMachineRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user);
            RecoveryCodesLeft = await _userManager.CountRecoveryCodesAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            await _signInManager.ForgetTwoFactorClientAsync();
            StatusMessage = "Ce navigateur a été oublié. Lors de votre prochaine connexion à partir de ce navigateur, vous devrez entrer votre code 2FA.";
            return RedirectToPage();
        }
    }
}
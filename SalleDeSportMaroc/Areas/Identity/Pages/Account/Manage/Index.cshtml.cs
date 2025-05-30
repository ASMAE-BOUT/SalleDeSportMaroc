// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalleDeSportMaroc.Models;

namespace SalleDeSportMaroc.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par d�faut d'ASP.NET Core Identity et n'est pas destin�e � �tre utilis�e
        ///     directement dans votre code. Cette API peut changer ou �tre supprim�e dans les futures versions.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par d�faut d'ASP.NET Core Identity et n'est pas destin�e � �tre utilis�e
        ///     directement dans votre code. Cette API peut changer ou �tre supprim�e dans les futures versions.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par d�faut d'ASP.NET Core Identity et n'est pas destin�e � �tre utilis�e
        ///     directement dans votre code. Cette API peut changer ou �tre supprim�e dans les futures versions.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par d�faut d'ASP.NET Core Identity et n'est pas destin�e � �tre utilis�e
        ///     directement dans votre code. Cette API peut changer ou �tre supprim�e dans les futures versions.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     Cette API prend en charge l'infrastructure d'interface utilisateur par d�faut d'ASP.NET Core Identity et n'est pas destin�e � �tre utilis�e
            ///     directement dans votre code. Cette API peut changer ou �tre supprim�e dans les futures versions.
            /// </summary>
            [Phone(ErrorMessage = "Le num�ro de t�l�phone n'est pas valide.")]
            [Display(Name = "Num�ro de t�l�phone")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Erreur inattendue lors de la mise � jour du num�ro de t�l�phone.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Votre profil a �t� mis � jour.";
            return RedirectToPage();
        }
    }
}
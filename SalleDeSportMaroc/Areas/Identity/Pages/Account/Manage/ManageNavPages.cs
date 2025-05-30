// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SalleDeSportMaroc.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
    ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
    /// </summary>
    public static class ManageNavPages
    {
        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string Index => "Index";

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string Email => "Email";

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string ChangePassword => "ChangePassword";

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string DownloadPersonalData => "DownloadPersonalData";

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string DeletePersonalData => "DeletePersonalData";

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string ExternalLogins => "ExternalLogins";

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string PersonalData => "PersonalData";

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string DownloadPersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DownloadPersonalData);

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string DeletePersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePersonalData);

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement dans votre code. Cette API peut changer ou être supprimée dans les futures versions.
        /// </summary>
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
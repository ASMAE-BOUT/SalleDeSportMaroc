using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using SalleDeSportMaroc.Data;
using SalleDeSportMaroc.Models;
using System.Globalization; // Ajouté pour la localisation
using Microsoft.AspNetCore.Localization; // Ajouté pour la localisation
using Microsoft.Extensions.Localization; // Ajouté pour les ressources

var builder = WebApplication.CreateBuilder(args);

// Configurer la localisation
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("fr-FR") };
    options.DefaultRequestCulture = new RequestCulture("fr-FR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Ajouter les ressources personnalisées pour Identity
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI() // Ajouté pour s'assurer que les pages Identity utilisent les ressources personnalisées
    .AddErrorDescriber<CustomIdentityErrorDescriber>(); // Ajouté pour personnaliser les messages d'erreur

builder.Services.AddAntiforgery();
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    context.Database.Migrate();

    // Créer le rôle "Admin" s'il n'existe pas
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }

    // Créer un utilisateur admin par défaut
    var adminEmail = "admin@marocactive.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
        await userManager.CreateAsync(adminUser, "Admin@123");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

    // Ajouter des coachs
    if (!context.Coachs.Any())
    {
        context.Coachs.AddRange(
            new Coach { Nom = "Youssef El Amrani", Specialite = "Musculation & Cardio", PhotoUrl = "/images/coachs/youssef.jpg" },
            new Coach { Nom = "Sara Bennani", Specialite = "Yoga & Pilates", PhotoUrl = "/images/coachs/sara.jpg" },
            new Coach { Nom = "Khalid Ouchen", Specialite = "CrossFit & HIIT", PhotoUrl = "/images/coachs/khalid.jpg" },
            new Coach { Nom = "Fatima Zahra Idrissi", Specialite = "Danse & Zumba", PhotoUrl = "/images/coachs/fatima.jpg" }
        );
        context.SaveChanges();
    }

    // Ajouter des séances
    if (!context.Sessions.Any())
    {
        context.Sessions.AddRange(
            new Session { Activity = "Yoga", Date = new DateTime(2025, 3, 21), Time = "10:00", Coach = "Sara Bennani" },
            new Session { Activity = "CrossFit", Date = new DateTime(2025, 3, 22), Time = "18:00", Coach = "Khalid Ouchen" }
        );
        context.SaveChanges();
    }

    // Ajouter des absences
    if (!context.Absences.Any())
    {
        context.Absences.AddRange(
            new Absence { Name = "Ahmed Benali", Type = "Membre", Date = new DateTime(2025, 3, 20), Reason = "Maladie" },
            new Absence { Name = "Sara Bennani", Type = "Coach", Date = new DateTime(2025, 3, 21), Reason = "Congé" }
        );
        context.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync($"An error occurred: {exception?.Message}\nStackTrace: {exception?.StackTrace}");
        });
    });
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseRequestLocalization(); // Ajouté pour activer la localisation
app.UseAntiforgery();
app.MapRazorPages();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public class CustomIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DefaultError() => new IdentityError { Code = nameof(DefaultError), Description = "Une erreur inconnue s'est produite." };
    // Ajoutez d'autres surcharges si nécessaire
}
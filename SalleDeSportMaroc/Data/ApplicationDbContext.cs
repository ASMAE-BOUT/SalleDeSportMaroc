using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalleDeSportMaroc.Models;

namespace SalleDeSportMaroc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Coach> Coachs { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Absence> Absences { get; set; }

    }
}

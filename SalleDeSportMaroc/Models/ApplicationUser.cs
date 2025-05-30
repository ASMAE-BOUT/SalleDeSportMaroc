using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalleDeSportMaroc.Models;

namespace SalleDeSportMaroc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
    }
}


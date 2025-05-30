using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalleDeSportMaroc.Models;

namespace SalleDeSportMaroc.Models
{
    public class Abonnement
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public double Prix { get; set; }
        public int DureeMois { get; set; }
        public string? UtilisateurId { get; set; }
        public ApplicationUser? Utilisateur { get; set; }
    }

}



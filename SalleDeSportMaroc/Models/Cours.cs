using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalleDeSportMaroc.Models;

namespace SalleDeSportMaroc.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public DateTime Horaire { get; set; }
        public int CoachId { get; set; }
        public Coach? Coach { get; set; }
    }

}



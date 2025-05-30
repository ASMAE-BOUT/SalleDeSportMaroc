using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalleDeSportMaroc.Models;
using System.ComponentModel.DataAnnotations;


namespace SalleDeSportMaroc.Models
{
    public class Coach
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom du Coach")]
        public string? Nom { get; set; }

        [Required]
        [Display(Name = "Spécialité")]
        public string? Specialite { get; set; }

        //[Required]
        //[Display(Name = "Expérience (en années)")]
        //public int Experience { get; set; }

        [Display(Name = "Photo du Coach")]
        public string? PhotoUrl { get; set; }
    }
}




namespace SalleDeSportMaroc.Models
{
    public class Absence
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; } // "Membre" ou "Coach"
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
    }
}
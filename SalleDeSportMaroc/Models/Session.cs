namespace SalleDeSportMaroc.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string? Activity { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Coach { get; set; }
    }
}
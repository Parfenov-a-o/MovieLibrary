namespace AEXTest1.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}

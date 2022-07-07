using System.ComponentModel.DataAnnotations;

namespace AEXTest1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Year { get; set; }
        public string? Country { get; set; }
        public Genres Genre { get; set; }

        public string? Description { get; set; }

        public List<Actor> Actors { get; set; } = new List<Actor>();

    }

    public enum Genres
    {
        [Display(Name = "Все жанры")]
        All,
        [Display(Name = "Комедия")]
        Comedy,
        [Display(Name = "Боевик")]
        Action,
        [Display(Name = "Приключения")]
        Adventure,
        [Display(Name = "Детектив")]
        Crime,
        [Display(Name = "Фантастика")]
        Fantasy,
        [Display(Name = "Исторический")]
        Historical,
        [Display(Name = "Мелодрама")]
        Romance,
    }
}

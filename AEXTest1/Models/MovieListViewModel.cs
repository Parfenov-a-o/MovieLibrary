using Microsoft.AspNetCore.Mvc.Rendering;

namespace AEXTest1.Models
{
    public class MovieListViewModel
    {
        //Collection to store movie list
        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
        //Property for selected genre
        public Genres SelectedValue { get; set;  }
        //Property for the name specified in the search
        public string? Name { get;set; }
    }
}

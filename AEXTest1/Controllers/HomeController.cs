using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AEXTest1.Models;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
            // add initial data if they are missing
            if (!db.Actors.Any())
            {
                Actor actor1 = new Actor { Name = "Александр", Surname = "Демьяненко", BirthDate = new DateTime(1937, 05, 30) };
                Actor actor2 = new Actor { Name = "Наталья", Surname = "Крачковская", BirthDate = new DateTime(1938, 11, 24) };
                Actor actor3 = new Actor { Name = "Наталья", Surname = "Селезнева", BirthDate = new DateTime(1945, 06, 19) };
                Actor actor4 = new Actor { Name = "Александр", Surname = "Михайлов", BirthDate = new DateTime(1944,10,5) };
                Actor actor5 = new Actor { Name = "Нина", Surname = "Дорошина", BirthDate = new DateTime(1934,12,3) };
                Actor actor6 = new Actor { Name = "Евгений", Surname = "Леонов", BirthDate = new DateTime(1926, 09, 2) };

                Movie movie1 = new Movie { Title = "Любовь и голуби", Country = "СССР", Year = "1984", Actors = { actor4, actor5 },
                    Genre = Genres.Romance };
                Movie movie2 = new Movie { Title = "Операция Ы и другие приключения Шурика", Country = "СССР", Year = "1965", 
                    Actors = { actor1, actor3 }, Genre = Genres.Comedy };
                Movie movie3 = new Movie { Title = "Джентльмены удачи", Country = "СССР", Year = "1971", Actors = { actor6 }, 
                    Genre = Genres.Comedy };
                Movie movie4 = new Movie { Title = "Иван Васильевич меняет профессию", Country = "СССР", Year = "1973", 
                    Actors = { actor1, actor2 }, Genre = Genres.Fantasy };

                db.Actors.AddRange(actor1,actor2,actor3,actor4,actor5,actor6);
                db.Movies.AddRange(movie1,movie2,movie3,movie4);

                db.SaveChanges();
               

            }
        }

        //Movie search method
        public ActionResult Index(string? name, Genres? genre, string typeSearch)
        {
            //add to the collection all the movies from the database
            IQueryable<Movie> movies = db.Movies.Include(m => m.Actors);

            //Null guard
            if(genre!=null && (int)genre!=0)
            {
                movies = movies.Where(m => m.Genre == genre);
            }
            //Checking the value specified in the search string
            if (!string.IsNullOrEmpty(name))
            {
                //Checking for the selected search method
                if (typeSearch == "titleSearching")
                {
                    movies = movies.Where(m => m.Title!.Contains(name));
                }
                if(typeSearch == "actorSearching")
                {
                    movies = movies.Where(m=>m.Actors.Where(a => a.Name!.Contains(name)).ToList().Count>0);
                }
               
            }
            //Create ViewModel
            MovieListViewModel viewModel = new MovieListViewModel
            {
                Movies = movies.ToList(),
                Name = name,

            };
            return View(viewModel);
            
        }
        //Method for displaying additional information
        public ActionResult Detail(int? id)
        {
            //null guard
            if(id!=null)
            {
                //Get the movie with the corresponding ID
                Movie? movie = db.Movies.Include(m=>m.Actors).First(m => m.Id == id);
                //null guard
                if(movie!=null)
                {
                    return View(movie);
                }
            }
            return NotFound();
            
        }
    }
}
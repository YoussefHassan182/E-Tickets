using E_Tickets.Models;

namespace E_Tickets.Data.ViewModels
{
    public class MoviewDropDownViewModel
    {
        public MoviewDropDownViewModel()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}

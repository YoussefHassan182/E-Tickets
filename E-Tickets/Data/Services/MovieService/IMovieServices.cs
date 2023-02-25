using E_Tickets.Data.Base;
using E_Tickets.Data.ViewModels;
using E_Tickets.Models;

namespace E_Tickets.Data.Services
{
    public interface IMovieServices : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieById(int id);
        Task<MoviewDropDownViewModel> GetNewMovieDropdownsValues();
        Task AddNewMovie(NewMovieVewModel data);
        Task UpdateMovie(NewMovieVewModel data);
    }
}

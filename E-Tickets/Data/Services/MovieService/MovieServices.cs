using E_Tickets.Data.Base;
using E_Tickets.Data.ViewModels;
using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Data.Services
{
    public class MovieServices : EntityBaseRepository<Movie>, IMovieServices
    {
        private readonly AppDbContext context;
        public MovieServices(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task AddNewMovie(NewMovieVewModel data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
             context.Movies.Add(newMovie);
            await context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new ActorMovie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                 context.ActorMovies.Add(newActorMovie);
            }
            await context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movieDetails = await context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.ActorsMovies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<MoviewDropDownViewModel> GetNewMovieDropdownsValues()
        {
            var response = new MoviewDropDownViewModel()
            {
                Actors = await context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovie(NewMovieVewModel data)
        {
            var dbMovie = await context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageUrl = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = context.ActorMovies.Where(n => n.MovieId == data.Id).ToList();
            context.ActorMovies.RemoveRange(existingActorsDb);
            await context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new ActorMovie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                 context.ActorMovies.Add(newActorMovie);
            }
            await context.SaveChangesAsync();
        }
    }
}

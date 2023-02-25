using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Data.UserRole;
using E_Tickets.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Controllers
{
    //[Authorize(Roles = UserRole.Admin)]
    public class MoviesController : Controller { 
    private readonly IMovieServices service;

    public MoviesController(IMovieServices _service)
    {
        service = _service;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var allMovies = await service.GetAll(n => n.Cinema);
        return View(allMovies);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Filter(string searchString)
    {
        var allMovies = await service.GetAll(n => n.Cinema);

        if (!string.IsNullOrEmpty(searchString))
        {
            //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

            var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return View("Index", filteredResultNew);
        }

        return View("Index", allMovies);
    }

    //GET: Movies/Details/1
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var movieDetail = await service.GetMovieById(id);
        return View(movieDetail);
    }

    //GET: Movies/Create
    public async Task<IActionResult> Create()
    {
        var movieDropdownsData = await service.GetNewMovieDropdownsValues();

        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewMovieVewModel movie)
    {
        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(movie);
        }

        await service.AddNewMovie(movie);
        return RedirectToAction(nameof(Index));
    }


    //GET: Movies/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var movieDetails = await service.GetMovieById(id);
        if (movieDetails == null) return View("NotFound");

        var response = new NewMovieVewModel()
        {
            Id = movieDetails.Id,
            Name = movieDetails.Name,
            Description = movieDetails.Description,
            Price = movieDetails.Price,
            StartDate = movieDetails.StartDate,
            EndDate = movieDetails.EndDate,
            ImageURL = movieDetails.ImageUrl,
            MovieCategory = movieDetails.MovieCategory,
            CinemaId = movieDetails.CinemaId,
            ProducerId = movieDetails.ProducerId,
            ActorIds = movieDetails.ActorsMovies.Select(n => n.ActorId).ToList(),
        };

        var movieDropdownsData = await service.GetNewMovieDropdownsValues();
        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, NewMovieVewModel movie)
    {
        if (id != movie.Id) return View("NotFound");

        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(movie);
        }

        await service.UpdateMovie(movie);
        return RedirectToAction(nameof(Index));
    }
}
    }




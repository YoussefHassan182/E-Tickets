using E_Tickets.Data.Services;
using E_Tickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Tickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaServices services;
        public CinemasController(ICinemaServices servicess)
        {
            services = servicess;
        }
        public async Task<IActionResult> Index()
        {
            var Cinemas = await services.GetAll();
            return View(Cinemas);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await services.Add(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await services.GetById(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        //Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await services.GetById(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await services.Update(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await services.GetById(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await services.GetById(id);
            if (cinemaDetails == null) return View("NotFound");

            await services.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
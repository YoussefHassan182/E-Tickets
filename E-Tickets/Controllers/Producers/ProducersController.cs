using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerServices service;

        public ProducersController(IProducerServices _service)
        {
            service = _service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await service.GetAll();
            return View(allProducers);
        }

        //GET: producers/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await service.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //GET: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await service.Add(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET: producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await service.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id)
            {
                await service.Update(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await service.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await service.GetById(id);
            if (producerDetails == null) return View("NotFound");

            await service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

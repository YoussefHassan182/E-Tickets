using E_Tickets.Data;
using E_Tickets.Data.Base;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Tickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorServices services;
        public ActorsController(IActorServices _services)
        {
          services = _services;
        }

        public async Task<IActionResult> Index()
        {
            var Actrors = await services.GetAll();
            return View(Actrors);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicUrl,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await services.Add(actor);
           
             RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await services.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await services.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePicUrl,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await services.Update(id, actor);
            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await services.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);

        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id,Actor actor)
        {
            var actorDetails = await services.GetById(id);
            if (actorDetails == null) return View("NotFound");
            await services.Delete(id);
            return RedirectToAction(nameof(Index));

        }


    }
    }


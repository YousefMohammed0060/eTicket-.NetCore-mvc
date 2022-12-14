using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _service;
        public ActorsController(IActorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allActors = await _service.getAllAsync();
            return View(allActors);
        }
        // Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            ModelState.Remove("Actors_Movies");
            if (ModelState.IsValid)
            {
                await _service.AddAsync(actor);
                return RedirectToAction(nameof(Index));
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(actor);
        }

        // Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);

        }

        // Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            ModelState.Remove("Actors_Movies");
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

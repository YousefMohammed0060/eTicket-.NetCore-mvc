using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.getAllAsync();
            return View(allProducers);
        }
        // Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            ModelState.Remove("Movies");
            if (ModelState.IsValid)
            {
                await _service.AddAsync(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails == null) return View("Not Found");
            return View(producersDetails);

        }

        // Producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails == null) return View("Not Found");
            return View(producersDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            ModelState.Remove("Movies");
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // Producers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails == null) return View("Not Found");
            return View(producersDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

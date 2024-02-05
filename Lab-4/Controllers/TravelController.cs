using Laboratorium_nr3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_nr3.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;
        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }
        public IActionResult Index()
        {
            return View(_travelService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Travel model)
        {
            if (ModelState.IsValid)
            {
                _travelService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_travelService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Travel model)
        {
            if (ModelState.IsValid)
            {
                _travelService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var travelToDelete = _travelService.FindById(id);
            if (travelToDelete == null)
            {
                return NotFound();
            }

            return View(travelToDelete);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var travelToDelete = _travelService.FindById(id);
            if (travelToDelete == null)
            {
                return NotFound();
            }

            _travelService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var travelDetails = _travelService.FindById(id);
            if (travelDetails == null)
            {
                return NotFound();
            }

            return View(travelDetails);
        }
    }
}

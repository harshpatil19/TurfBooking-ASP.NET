using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TurfBookingSystem.Models;

namespace TurfBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly TurfDbContext turfDb;

        public HomeController (TurfDbContext turfDb)
        {
            this.turfDb = turfDb;
        }

        public IActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Location")
            {
                var turfdata = turfDb.turf.Where(model => model.Location == search).ToList();
                return View(turfdata);
            }
            else
            {
                var turfdata = turfDb.turf.ToList();
                return View(turfdata);
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Turf trf)
        {
            if (ModelState.IsValid)
            {
                await turfDb.turf.AddAsync(trf);
                await turfDb.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
           var turfdata= await turfDb.turf.FirstOrDefaultAsync(x => x.TurfId == id);
            return View(turfdata);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var turfdata = await turfDb.turf.FindAsync(id);
            return View(turfdata);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Turf trf)
        {
            if (ModelState.IsValid)
            {
                turfDb.Update(trf);
                await turfDb.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var turfdata = await turfDb.turf.FirstOrDefaultAsync(x => x.TurfId == id);
            return View(turfdata);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteData(int? id)
        {

            var turfdata = await turfDb.turf.FindAsync(id);
            turfDb.turf.Remove(turfdata);
            await turfDb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
           
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComfortController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IComfortService _comfortService;
        private readonly IWebHostEnvironment _env;

        public ComfortController(AppDbContext context,
                                 IComfortService comfortService,
                                 IWebHostEnvironment env)
        {
            _context = context;
            _comfortService = comfortService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            Comfort comfort = await _comfortService.GetComfortAsync();

            return View(comfort);
        }

        [HttpGet]
        public async Task<IActionResult> Detail()
        {
            Comfort comfort = await _comfortService.GetComfortAsync();

            if (comfort is null) return NotFound();

            return View(comfort);
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            Comfort comfort = await _comfortService.GetComfortAsync();

            ComfortEditVM model = new()
            {
                Title = comfort.Title,
                Phone = comfort.Phone,
                Description = comfort.Description,
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ComfortEditVM model)
        {

            //Tag tag = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            Comfort comfort = await _comfortService.GetComfortAsync();

            if (comfort == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            comfort.Title = model.Title;
            comfort.Phone = model.Phone;
            comfort.Description = model.Description;

            _context.Comforts.Update(comfort);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }




    }
}

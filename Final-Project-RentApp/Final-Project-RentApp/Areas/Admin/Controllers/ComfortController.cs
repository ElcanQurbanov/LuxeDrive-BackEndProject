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
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Comfort comfort = await _comfortService.GetByIdAsync((int)id);

            if (comfort is null) return NotFound();

            return View(comfort);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComfortCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Comfort comfort = new()
            {
                Title = model.Title,
                Phone = model.Phone,
                Description = model.Description,
            };

            await _context.Comforts.AddAsync(comfort);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Comfort comfort = await _comfortService.GetByIdAsync(id);

            ComfortEditVM model = new()
            {
                Title = comfort.Title,
                Phone = comfort.Phone,
                Description = comfort.Description,
                Id = id
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ComfortEditVM model, int id)
        {
            if (id == null) return BadRequest();

            //Tag tag = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            Comfort comfort = await _comfortService.GetByIdAsync(id);

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

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                Comfort comfort = await _comfortService.GetByIdAsync((int)id);

                if (comfort is null) return NotFound();

                _context.Comforts.Remove(comfort);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}

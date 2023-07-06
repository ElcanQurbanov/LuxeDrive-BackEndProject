using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvantageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAdvantageService _advantageService;
        private readonly IWebHostEnvironment _env;

        public AdvantageController(AppDbContext context,
                                   IAdvantageService advantageService,
                                   IWebHostEnvironment env)
        {
            _context = context;
            _advantageService = advantageService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Advantage> advantages = await _advantageService.GetAllAsync();

            return View(advantages);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Advantage advantage = await _advantageService.GetByIdAsync((int)id);

            if (advantage is null) return NotFound();

            return View(advantage);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvantageCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Advantage advantage = new()
            {
                Title = model.Title,
                Description = model.Description,
            };

            await _context.Advantages.AddAsync(advantage);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Advantage advantage = await _advantageService.GetByIdAsync(id);

            AdvantageEditVM model = new()
            {
                Title = advantage.Title,
                Description = advantage.Description,
                Id = id
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdvantageEditVM model, int id)
        {
            if (id == null) return BadRequest();

            //Tag tag = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            Advantage advantage = await _advantageService.GetByIdAsync(id);

            if (advantage == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            advantage.Title = model.Title;
            advantage.Description = model.Description;

            _context.Advantages.Update(advantage);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {

            try
            {
                if (id == null) return BadRequest();

                Advantage advantage = await _advantageService.GetByIdAsync((int)id);

                if (advantage is null) return NotFound();

                _context.Advantages.Remove(advantage);

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

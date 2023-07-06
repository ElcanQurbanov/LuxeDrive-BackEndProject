using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IExperienceService _experienceService;


        public ExperienceController(AppDbContext context, 
                                    IWebHostEnvironment env,
                                    IExperienceService experienceService)
        {
            _context = context;
            _env = env;
            _experienceService = experienceService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Experience> experiences = await _experienceService.GetAllAsync();

            return View(experiences);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Experience experience = await _experienceService.GetByIdAsync((int)id);

            if (experience is null) return NotFound();

            return View(experience);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExperienceCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Experience experience = new()
            {
                Title = model.Title,
                Description = model.Description,
            };

            await _context.Experiences.AddAsync(experience);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Experience experience = await _experienceService.GetByIdAsync(id);

            ExperienceEditVM model = new()
            {
                Title = experience.Title,
                Description = experience.Description,
                Id = id
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExperienceEditVM model, int id)
        {
            if (id == null) return BadRequest();

            //Tag tag = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            Experience experience = await _experienceService.GetByIdAsync(id);

            if (experience == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            experience.Title = model.Title;
            experience.Description = model.Description;

            _context.Experiences.Update(experience);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                Experience experience = await _experienceService.GetByIdAsync((int)id);

                if (experience is null) return NotFound();

                _context.Experiences.Remove(experience);

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

using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITagService _tagService;

        public TagController(AppDbContext context,
                             ITagService tagService)
        {
            _context = context;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Tag> tags = await _tagService.GetAllAsync();

            return View(tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Tag tag = new()
            {
                Name = model.Name
            };

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Tag tag = await _tagService.GetByIdAsync(id);

            TagEditVM model = new()
            {
                Name = tag.Name,
                Id = id
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TagEditVM model, int id)
        {
            if (id == null) return BadRequest();

            //Tag tag = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            Tag tag = await _tagService.GetByIdAsync(id);

            if (tag == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            tag.Name = model.Name;

            _context.Tags.Update(tag);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {

            try
            {
                if (id == null) return BadRequest();

                Tag tag = await _tagService.GetByIdAsync((int)id);

                if (tag is null) return NotFound();

                _context.Tags.Remove(tag);

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

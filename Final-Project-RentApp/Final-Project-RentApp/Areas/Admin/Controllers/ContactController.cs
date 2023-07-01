using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IContactService _contactService;

        public ContactController(AppDbContext context,
                                 IWebHostEnvironment env,
                                 IContactService contactService)
        {
            _context = context;
            _env = env;
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Contact> contacts = await _contactService.GetAllAsync();

            return View(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Contact contact = await _contactService.GetByIdAsync((int)id);

            if (contact is null) return NotFound();

            return View(contact);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Contact contact = new()
            {
                City = model.City,
                Phone = model.Phone,
                Street = model.Street,
                WorkTime = model.WorkTime,
            };

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Contact contact = await _contactService.GetByIdAsync(id);

            ContactEditVM model = new()
            {
                City = contact.City,
                Phone = contact.Phone,
                Street = contact.Street,
                WorkTime = contact.WorkTime,
                Id = id
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactEditVM model, int id)
        {
            if (id == null) return BadRequest();

            //Tag tag = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            Contact contact = await _contactService.GetByIdAsync(id);

            if (contact == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            contact.City = model.City;
            contact.Phone = model.Phone;
            contact.Street = model.Street;
            contact.WorkTime = model.WorkTime;

            _context.Contacts.Update(contact);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                Contact contact = await _contactService.GetByIdAsync((int)id);

                if (contact is null) return NotFound();

                _context.Contacts.Remove(contact);

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

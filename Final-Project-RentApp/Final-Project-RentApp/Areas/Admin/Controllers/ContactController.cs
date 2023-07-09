using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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

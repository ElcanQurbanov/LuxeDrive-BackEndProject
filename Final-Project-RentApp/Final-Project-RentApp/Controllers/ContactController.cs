using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Final_Project_RentApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IPremiumRentalService _premiumRentalService;
        private readonly IStaticDataService _staticDataService;
        private readonly AppDbContext _context;


        public ContactController(IContactService contactService,
                                 IPremiumRentalService premiumRentalService,
                                 IStaticDataService staticDataService,
                                 AppDbContext context)
        {
            _contactService = contactService;
            _premiumRentalService = premiumRentalService;
            _staticDataService = staticDataService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //IEnumerable<Contact> contacts = await _contactService.GetAllAsync();
            PremiumRental premiumRental = await _premiumRentalService.GetPremiumRentalAsync();
            Dictionary<string, string> sectionHeaders = _staticDataService.GetAllSectionHeader();


            ContactVM model = new()
            {
                //Contacts = contacts,
                PremiumRental = premiumRental,
                SectionHeaders = sectionHeaders
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactVM model)
        {
            if (!ModelState.IsValid)
            {
                model.SectionHeaders = _staticDataService.GetAllSectionHeader();
                model.PremiumRental = await _premiumRentalService.GetPremiumRentalAsync();
                return View(model);
            }

            Contact contact = new Contact
            {
                FullName = model.Contact.FullName,
                Email = model.Contact.Email,
                Subject = model.Contact.Subject,
                Message = model.Contact.Message
            };

            await _context.AddAsync(contact);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
           
        }


    }
}

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

        public ContactController(IContactService contactService,
                                 IPremiumRentalService premiumRentalService)
        {
            _contactService = contactService;
            _premiumRentalService = premiumRentalService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Contact> contacts = await _contactService.GetAllAsync();
            PremiumRental premiumRental = await _premiumRentalService.GetPremiumRentalAsync();

            ContactVM model = new()
            {
                Contacts = contacts,
                PremiumRental = premiumRental
            };

            return View(model);
        }
    }
}

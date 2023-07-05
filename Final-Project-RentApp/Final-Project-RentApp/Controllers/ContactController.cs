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


        public ContactController(IContactService contactService,
                                 IPremiumRentalService premiumRentalService,
                                 IStaticDataService staticDataService)
        {
            _contactService = contactService;
            _premiumRentalService = premiumRentalService;
            _staticDataService = staticDataService;

        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Contact> contacts = await _contactService.GetAllAsync();
            PremiumRental premiumRental = await _premiumRentalService.GetPremiumRentalAsync();
            Dictionary<string, string> sectionHeaders = _staticDataService.GetAllSectionHeader();


            ContactVM model = new()
            {
                Contacts = contacts,
                PremiumRental = premiumRental,
                SectionHeaders = sectionHeaders
            };

            return View(model);
        }
    }
}

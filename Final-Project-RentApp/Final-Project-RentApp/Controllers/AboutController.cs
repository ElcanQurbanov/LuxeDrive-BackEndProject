using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Final_Project_RentApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly IExperienceService _experienceService;
        private readonly IPremiumRentalService _premiumRentalService;

        public AboutController(IExperienceService experienceService,
                               IPremiumRentalService premiumRentalService)
        {
            _experienceService = experienceService;
            _premiumRentalService = premiumRentalService;

        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Experience> experiences = await _experienceService.GetAllAsync();
            PremiumRental premiumRental = await _premiumRentalService.GetPremiumRentalAsync();

            AboutVM model = new()
            {
                Experiences = experiences,
                PremiumRental = premiumRental
            };

            return View(model);
        }
    }
}

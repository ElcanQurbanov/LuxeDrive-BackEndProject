using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Final_Project_RentApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly IExperienceService _experienceService;
        private readonly IFaqService _faqService;
        private readonly IPremiumRentalService _premiumRentalService;

        public AboutController(IExperienceService experienceService,
                               IFaqService faqService,
                               IPremiumRentalService premiumRentalService)
        {
            _experienceService = experienceService;
            _faqService = faqService;
            _premiumRentalService = premiumRentalService;

        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Experience> experiences = await _experienceService.GetAllAsync();
            IEnumerable<Faq> faqs = await _faqService.GetAllAsync();
            PremiumRental premiumRental = await _premiumRentalService.GetPremiumRentalAsync();

            AboutVM model = new()
            {
                Experiences = experiences,
                Faqs = faqs,
                PremiumRental = premiumRental
            };

            return View(model);
        }
    }
}

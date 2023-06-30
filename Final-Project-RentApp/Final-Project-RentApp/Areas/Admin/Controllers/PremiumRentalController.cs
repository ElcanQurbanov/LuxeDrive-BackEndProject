using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PremiumRentalController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPremiumRentalService _premiumRentalService;
        private readonly IWebHostEnvironment _env;

        public PremiumRentalController(AppDbContext context,
                                       IPremiumRentalService premiumRentalService,
                                       IWebHostEnvironment env)
        {
            _context = context;
            _premiumRentalService = premiumRentalService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            PremiumRental premiumRental = await _premiumRentalService.GetPremiumRentalAsync();

            return View(premiumRental);
        }
    }
}

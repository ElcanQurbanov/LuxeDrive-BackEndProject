using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvantageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAdvantageService _advantageService;
        private readonly IWebHostEnvironment _env;

        public AdvantageController(AppDbContext context,
                                   IAdvantageService advantageService,
                                   IWebHostEnvironment env)
        {
            _context = context;
            _advantageService = advantageService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Advantage> advantages = await _advantageService.GetAllAsync();

            return View(advantages);
        }
    }
}

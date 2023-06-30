using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComfortController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IComfortService _comfortService;
        private readonly IWebHostEnvironment _env;

        public ComfortController(AppDbContext context,
                                 IComfortService comfortService,
                                 IWebHostEnvironment env)
        {
            _context = context;
            _comfortService = comfortService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            Comfort comfort = await _comfortService.GetComfortAsync();

            return View(comfort);
        }
    }
}

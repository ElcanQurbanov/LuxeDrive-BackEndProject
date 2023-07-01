using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICarService _carService;
        private readonly IWebHostEnvironment _env;

        public CarController(AppDbContext context,
                             ICarService carService,
                             IWebHostEnvironment env)
        {
            _context = context;
            _carService = carService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await _carService.GetAllAsync();

            return View(cars);
        }
    }
}

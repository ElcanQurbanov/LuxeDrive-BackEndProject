using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarClassController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICarClassService _carClassService;
        private readonly IWebHostEnvironment _env;


        public CarClassController(AppDbContext context,
                                  ICarClassService carClassService,
                                  IWebHostEnvironment env)
        {
            _context = context;
            _carClassService = carClassService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CarClass> carClasses = await _carClassService.GetAllAsync();

            return View(carClasses);
        }
    }
}

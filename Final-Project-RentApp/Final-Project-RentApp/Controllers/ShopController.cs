using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Final_Project_RentApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICarService _carService;

        public ShopController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await _carService.GetAllAsync();

            ShopVM model = new()
            {
                Cars = cars
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}

using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Controllers
{   
    public class SearchController : Controller
    {
        private readonly ICarService _carService;

        public SearchController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> SearchByCars(string searchText)
        {
            if (searchText == null) return BadRequest();

            return View(await _carService.SearchAsync(searchText));
        }

    }
}

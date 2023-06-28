//using Final_Project_RentApp.Models;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Final_Project_RentApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final_Project_RentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IComfortService _comfortService;
        private readonly ICarService _carService;
        private readonly IAdvantageService _advantageService;
        private readonly IQuaranteeService _quaranteeService;
        private readonly ITeamService _teamService;
        private readonly IPremiumRentalService _premiumRentalService;
        private readonly ICarClassService _carClassService;

        public HomeController(ISliderService sliderService,
                              IComfortService comfortService,
                              ICarService carService,
                              IAdvantageService advantageService,
                              IQuaranteeService quaranteeService,
                              IPremiumRentalService premiumRentalService,
                              ITeamService teamService,
                              ICarClassService carClassService)
        {
            _sliderService = sliderService;
            _comfortService = comfortService;
            _carService = carService;
            _advantageService = advantageService;
            _quaranteeService = quaranteeService;
            _teamService = teamService;
            _premiumRentalService = premiumRentalService;
            _carClassService = carClassService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _sliderService.GetAllAsync();
            Comfort comfort = await _comfortService.GetComfortAsync();
            IEnumerable<Car> cars = await _carService.GetAllAsync();
            IEnumerable<Advantage> advantages = await _advantageService.GetAllAsync();
            Quarantee quarantee = await _quaranteeService.GetQuaranteeAsync();
            IEnumerable<Team> teams = await _teamService.GetAllAsync();
            PremiumRental premiumRental = await _premiumRentalService.GetPremiumRentalAsync();
            IEnumerable<CarClass> carClasses = await _carClassService.GetAllAsync();

            HomeVM model = new()
            {
                Sliders = sliders,
                Comfort = comfort,
                Cars = cars,
                Advantages = advantages,
                Quarantee = quarantee,
                Teams = teams,
                PremiumRental = premiumRental,
                CarClasses = carClasses
            };

            return View(model);
        }

    }
}
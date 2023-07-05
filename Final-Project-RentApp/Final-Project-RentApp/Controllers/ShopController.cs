using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Final_Project_RentApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.XPath;

namespace Final_Project_RentApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICarService _carService;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public ShopController(ICarService carService,UserManager<AppUser> userManager, AppDbContext context)
        {
            _carService = carService;
        _userManager = userManager;
           _context = context;
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

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)id);

            if (car == null) return NotFound();

            return View(car);
        }

        [HttpPost]

        public async Task<IActionResult> Detail(int? id,Car cars)
        {
            TempData["Order"] = false;
            if (id == null) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)id);

            if (car == null) return BadRequest();

            if(User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                if(cars.OrderVM is not null)
                {
                    if(cars.OrderVM.Date < DateTime.Now) return View(car);

                    bool dublicate =_context.OrderItems.Any(x=>x.Date==cars.OrderVM.Date);

                    if (dublicate ==true) return View(car);

                    OrderItem orderItem = new()
                    {
                        Username = cars.OrderVM.Username,
                        Phone=cars.OrderVM.Phone,
                        Date=cars.OrderVM.Date,
                        AppUserId=user.Id,
                        CarId=car.Id,
                        Status=OrderStatus.Pending
                    };

                    _context.OrderItems.Add(orderItem);

                    _context.SaveChanges();
                }
            }
            else
            {
                return RedirectToAction("login", "account");
            }

            if (car == null) return NotFound();

            TempData["Order"] = true;

            return RedirectToAction(nameof(Index));
        }
    }
}

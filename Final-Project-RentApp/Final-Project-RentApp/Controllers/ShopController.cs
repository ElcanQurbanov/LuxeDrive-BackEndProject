using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Final_Project_RentApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.XPath;

namespace Final_Project_RentApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICarService _carService;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IOrderService _orderService;
        private readonly IStaticDataService _staticDataService;


        public ShopController(ICarService carService,
                              UserManager<AppUser> userManager,
                              AppDbContext context,
                              IOrderService orderService,
                              IStaticDataService staticDataService)
        {
            _carService = carService;
            _userManager = userManager;
            _context = context;
            _orderService = orderService;
            _staticDataService = staticDataService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await _carService.GetAllAsync();
            Dictionary<string, string> sectionHeaders = _staticDataService.GetAllSectionHeader();

            ShopVM model = new()
            {
                Cars = cars,
                SectionHeaders = sectionHeaders
            };
            
            ViewBag.Categories = _context.Categories.ToList();

            return View(model);

        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)id);

            if (car == null) return NotFound();


            CarDetailVM model = new CarDetailVM()
            {
                Car = car,
                CarComments = car.CarComments
            };

            return View(car);
        }


        [HttpPost]
        public async Task<IActionResult> Detail(int? id, Car cars)
        {
            TempData["Order"] = false;

            if (id == null) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)id);

            if (car == null) return BadRequest();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (cars.OrderVM is not null)
                {
                    if (cars.OrderVM.Date < DateTime.Now) return View(car);

                    bool dublicate = _context.OrderItems.Any(m => m.Date.Date.Day == cars.OrderVM.Date.Date.Day
                                                                 && m.Date.Date.Month == cars.OrderVM.Date.Date.Month
                                                                 && m.Date.Date.Year == cars.OrderVM.Date.Date.Year
                                                                 && m.CarId == car.Id && m.Status==OrderStatus.Accepted);
                    if (dublicate == true) return View(car);

                    OrderItem orderItem = new()
                    {
                        Username = cars.OrderVM.Username,
                        Phone = cars.OrderVM.Phone,
                        Date = cars.OrderVM.Date,
                        AppUserId = user.Id,
                        CarId = car.Id,
                        Status = OrderStatus.Pending
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



        [HttpPost, Authorize]
        public async Task<IActionResult> PostComment(CarDetailVM model, string userId, int carId)
        {
            if (model.CommentVM.Message == null)
            {
                return RedirectToAction(nameof(Detail), new { id = carId });
            }

            CarComment carComment = new()
            {
                Message = model.CommentVM.Message,
                AppUserId = userId,
                CarId = carId
            };

            await _context.CarComments.AddAsync(carComment);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Detail), new { id = carId });


        }




    }
}

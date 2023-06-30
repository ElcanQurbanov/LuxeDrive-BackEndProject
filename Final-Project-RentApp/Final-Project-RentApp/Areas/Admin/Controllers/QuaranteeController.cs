using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuaranteeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IQuaranteeService _quaranteeService;
        private readonly IWebHostEnvironment _env;

        public QuaranteeController(AppDbContext context, 
                                   IQuaranteeService quaranteeService,
                                   IWebHostEnvironment env)
        {
            _context = context;
            _quaranteeService = quaranteeService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            Quarantee quarantee = await _quaranteeService.GetQuaranteeAsync();

            return View(quarantee);
        }
    }
}

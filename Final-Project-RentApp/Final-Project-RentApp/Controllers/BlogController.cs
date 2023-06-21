using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

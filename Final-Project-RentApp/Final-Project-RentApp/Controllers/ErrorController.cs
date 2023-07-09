using Microsoft.AspNetCore.Mvc;

namespace Final_Project_RentApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            return View();
        }
    }
}

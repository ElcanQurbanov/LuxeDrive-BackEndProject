using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class SliderCreateVM
    {
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public IFormFile BackGroundImage { get; set; }
    }
}

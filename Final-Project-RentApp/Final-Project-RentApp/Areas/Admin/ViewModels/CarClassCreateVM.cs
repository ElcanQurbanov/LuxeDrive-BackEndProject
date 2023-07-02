using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class CarClassCreateVM
    {
        [Required]
        public string StartPrice { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class CarClassEditVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StartPrice { get; set; }

        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class CarCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Extra { get; set; }

        public int CarClassId { get; set; }

        public List<int> CarCategories { get; set; } = new();

        public List<int> CarTags { get; set; } = new();

        [Required]
        public List<IFormFile> Photos { get; set; }
    }
}

using Final_Project_RentApp.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class CarEditVM
    {
        public int Id { get; set; }
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

        public List<int> CarCategoriesId { get; set; } = new();

        public List<int> CarTagsId { get; set; } = new();

   
        public List<IFormFile> Photos { get; set; }

        public ICollection<CarImage> Images { get; set; }
    }
}

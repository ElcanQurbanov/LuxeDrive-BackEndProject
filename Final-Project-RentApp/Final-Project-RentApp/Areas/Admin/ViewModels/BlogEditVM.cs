using Final_Project_RentApp.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class BlogEditVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<BlogImage> blogImages { get; set; }

        public List<IFormFile> Photos { get; set; }
    }
}

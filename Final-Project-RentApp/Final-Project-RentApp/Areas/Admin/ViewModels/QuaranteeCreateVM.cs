using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class QuaranteeCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class QuaranteeEditVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Description { get; set; }

        public IEnumerable<string> Image { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class ComfortEditVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

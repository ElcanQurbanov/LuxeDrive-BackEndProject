using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class TagCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}

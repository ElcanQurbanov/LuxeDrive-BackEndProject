using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class CategoryCreateVM
    {
        [Required]
        public string Name { get; set; }
    }
}

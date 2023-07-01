using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class TagEditVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

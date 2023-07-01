using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Areas.Admin.ViewModels
{
    public class ContactEditVM
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string WorkTime { get; set; }
    }
}

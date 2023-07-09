using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.ViewModels
{
    public class CommentVM
    {
        [Required]
        public string Message { get; set; }
    }
}

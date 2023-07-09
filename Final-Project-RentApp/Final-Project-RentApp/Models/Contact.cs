using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.Models
{
    public class Contact : BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}

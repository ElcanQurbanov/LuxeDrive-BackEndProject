using Final_Project_RentApp.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_RentApp.Models
{
    public class Car : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Extra { get; set; }
        public int CarClassId { get; set; }
        public CarClass CarClass { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<CarImage> CarImages { get; set; }
        public ICollection<CarTag> CarTags { get; set; }
        public ICollection<CarCategory> CarCategories { get; set; }

        [NotMapped]
        public OrderVM OrderVM { get; set; }
    }
}

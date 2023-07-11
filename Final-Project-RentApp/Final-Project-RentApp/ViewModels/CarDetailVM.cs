using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.ViewModels
{
    public class CarDetailVM
    {
        public Car Car { get; set; }
        public IEnumerable<CarComment> CarComments { get; set; }
        public CommentVM CommentVM { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Extra { get; set; }

        public int CarClassId { get; set; }
        public CarClass CarClass { get; set; }

        public IEnumerable<string> Images { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> Categories { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

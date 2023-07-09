using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.ViewModels
{
    public class CarDetailVM
    {
        public Car Car { get; set; }
        public IEnumerable<CarComment> CarComments { get; set; }
        public CommentVM CommentVM { get; set; }
    }
}

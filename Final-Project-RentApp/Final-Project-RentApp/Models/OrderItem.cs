using Final_Project_RentApp.Helpers;

namespace Final_Project_RentApp.Models
{
    public class OrderItem : BaseEntity
    {
        public string Username { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public OrderStatus Status { get; set; }
    }
}

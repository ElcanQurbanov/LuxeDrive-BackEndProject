namespace Final_Project_RentApp.Models
{
    public class CarComment : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Message { get; set; }
    }
}

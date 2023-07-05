namespace Final_Project_RentApp.Models
{
    public class WishlistItem : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

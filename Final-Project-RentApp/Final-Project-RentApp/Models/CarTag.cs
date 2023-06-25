namespace Final_Project_RentApp.Models
{
    public class CarTag : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}

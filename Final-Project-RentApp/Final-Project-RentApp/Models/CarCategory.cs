namespace Final_Project_RentApp.Models
{
    public class CarCategory : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

namespace Final_Project_RentApp.Models
{
    public class CarImage : BaseEntity
    {
        public string Image { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public bool IsMain { get; set; } = false;
        public bool IsPreview { get; set; } = false;
    }
}

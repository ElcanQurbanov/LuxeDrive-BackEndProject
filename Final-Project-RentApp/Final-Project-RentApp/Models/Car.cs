namespace Final_Project_RentApp.Models
{
    public class Car : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CarClassId { get; set; }
        public CarClass CarClass { get; set; }
        public ICollection<CarImage> CarImages { get; set; }
        //public ICollection<Category> Categories { get; set; }
    }
}

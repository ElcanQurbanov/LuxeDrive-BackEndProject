namespace Final_Project_RentApp.Models
{
    public class CarClassInfo : BaseEntity
    {
        public string Info { get; set; }
        public int CarClassId { get; set; }
        public CarClass CarClass { get; set; }
    }
}

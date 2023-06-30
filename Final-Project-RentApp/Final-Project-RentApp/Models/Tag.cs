namespace Final_Project_RentApp.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CarTag> CarTags { get; set; }
    }
}

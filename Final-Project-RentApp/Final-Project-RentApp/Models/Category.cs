namespace Final_Project_RentApp.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CarCategory> CarCategories { get; set; }
    }
}

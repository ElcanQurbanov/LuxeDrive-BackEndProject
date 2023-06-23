namespace Final_Project_RentApp.Models
{
    public class PremiumRental : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ExperienceTitle { get; set; }
        public int ExperienceCount { get; set; }
        public ICollection<PremiumRentalImage> PremiumRentalImages { get; set; }
    }
}

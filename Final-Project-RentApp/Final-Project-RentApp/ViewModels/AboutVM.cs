using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.ViewModels
{
    public class AboutVM
    {
        public IEnumerable<Experience> Experiences { get; set; }
        public IEnumerable<Faq> Faqs { get; set; }
        public PremiumRental PremiumRental { get; set; }
    }
}

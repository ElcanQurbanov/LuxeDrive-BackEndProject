using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.ViewModels
{
    public class ContactVM
    {
        public Contact Contact { get; set; }
        public PremiumRental PremiumRental { get; set; }
        public Dictionary<string, string> SectionHeaders { get; set; }
    }
}

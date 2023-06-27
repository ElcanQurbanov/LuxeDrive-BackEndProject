using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.ViewModels
{
    public class ContactVM
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public PremiumRental PremiumRental { get; set; }
    }
}

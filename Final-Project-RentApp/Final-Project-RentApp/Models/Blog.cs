using System.Formats.Asn1;

namespace Final_Project_RentApp.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public int CarClassId { get; set; }
        //public CarClass CarClass { get; set; }
        public ICollection<BlogImage> BlogImages { get; set; }
    }
}

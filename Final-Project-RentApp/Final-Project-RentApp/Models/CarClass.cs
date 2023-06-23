namespace Final_Project_RentApp.Models
{
    public class CarClass : BaseEntity
    {
        public decimal StartPrice { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public ICollection<CarClassInfo> CarClassInfos { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}

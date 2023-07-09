using Final_Project_RentApp.Models;

namespace Final_Project_RentApp.ViewModels
{
    public class BlogVM
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public Dictionary<string, string> SectionHeaders { get; set; }
    }
}

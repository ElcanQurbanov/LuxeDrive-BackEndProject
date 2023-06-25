using Final_Project_RentApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_RentApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Comfort> Comforts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<Quarantee> Quarantees { get; set; }
        public DbSet<QuaranteeImage> QuaranteeImages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PremiumRental> PremiumRentals { get; set; }
        public DbSet<PremiumRentalImage> PremiumRentalImages { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<CarClassInfo> CarClassInfos { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}

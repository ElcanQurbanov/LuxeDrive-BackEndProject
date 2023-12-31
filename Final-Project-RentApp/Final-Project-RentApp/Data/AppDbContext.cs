﻿using Final_Project_RentApp.Models;
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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<CarTag> CarTags { get; set; }
        public DbSet<SectionHeader> SectionHeaders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<CarComment> CarComments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slider>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Comfort>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Car>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<CarImage>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Advantage>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Quarantee>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<QuaranteeImage>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Team>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<PremiumRental>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<PremiumRentalImage>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<CarClass>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<CarClassInfo>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Experience>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Faq>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Blog>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<BlogImage>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Contact>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Tag>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Category>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<Setting>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<CarCategory>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<CarTag>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<SectionHeader>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<OrderItem>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<WishlistItem>().HasQueryFilter(s => !s.SoftDelete);
            modelBuilder.Entity<CarComment>().HasQueryFilter(s => !s.SoftDelete);
        }

    }
}

using Final_Project_RentApp.Data;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSession();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));  // confuragsiya qurur 
});

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//builder.Services.Configure<IdentityOptions>(opt =>
//{
//    opt.Password.RequiredLength = 8;
//    opt.Password.RequireDigit = true;
//    opt.Password.RequireLowercase = true;
//    opt.Password.RequireUppercase = true;
//    opt.Password.RequireNonAlphanumeric = true;

//    opt.User.RequireUniqueEmail = true;
//    opt.SignIn.RequireConfirmedEmail = true;

//    opt.Lockout.MaxFailedAccessAttempts = 3;
//    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
//    opt.Lockout.AllowedForNewUsers = true;
//});

//builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));


builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IComfortService, ComfortService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IAdvantageService, AdvantageService>();
builder.Services.AddScoped<IQuaranteeService, QuaranteeService>();
builder.Services.AddScoped<IPremiumRentalService, PremiumRentalService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

//app.UseSession();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

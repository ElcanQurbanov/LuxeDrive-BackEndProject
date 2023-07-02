using Final_Project_RentApp.Areas.Admin.ViewModels;
using Final_Project_RentApp.Data;
using Final_Project_RentApp.Helpers;
using Final_Project_RentApp.Models;
using Final_Project_RentApp.Services;
using Final_Project_RentApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Final_Project_RentApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _env;

        public BlogController(AppDbContext context,
                              IBlogService blogService,
                              IWebHostEnvironment env)
        {
            _context = context;
            _blogService = blogService;
            _env = env;

        }

        public async Task<IActionResult> Index()
        {
            //IEnumerable<Blog> blogs = await _blogService.GetAllAsync();
            IEnumerable<Blog> blogs = await _context.Blogs.Include(bi => bi.BlogImages).ToListAsync();

            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            //Blog blog = await _blogService.GetByIdAsync((int)id);

            Blog blog = await _context.Blogs.Include(bi => bi.BlogImages).FirstOrDefaultAsync(m => m.Id == id);

            if (blog is null) return NotFound();

            return View(blog);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateVM blog)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                foreach (var photo in blog.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View();
                    }

                    if (!photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View();
                    }
                }

                List<BlogImage> blogImages = new();

                foreach (var photo in blog.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/blog", fileName);

                    await FileHelper.SaveFileAsync(path, photo);

                    BlogImage blogImage = new()
                    {
                        Image = fileName
                    };

                    blogImages.Add(blogImage);

                }

                blogImages.FirstOrDefault().IsMain = true;

                Blog newBlog = new()
                {
                    Title = blog.Title,
                    Description = blog.Description,
                    BlogImages = blogImages
                };

                await _context.BlogImages.AddRangeAsync(blogImages);
                await _context.Blogs.AddAsync(newBlog);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            catch (Exception)
            {
                throw;
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    try
        //    {
        //        if (id == null) return BadRequest();

        //        //Blog blog = await _blogService.GetFullDataByIdAsync((int)id);
        //        Blog blog = await _blogService.GetByIdAsync((int)id);

        //        if (blog is null) return NotFound();

        //        foreach (var item in blog.BlogImages)
        //        {
        //            string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/blog", item.Image);

        //            FileHelper.DeleteFile(path);
        //        }

        //        _context.Blogs.Remove(blog);

        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<IActionResult> Delete(int? id)
        {

            try
            {
                if (id == null) return BadRequest();

                Blog blog = await _blogService.GetByIdAsync((int)id);

                if (blog is null) return NotFound();

                _context.Blogs.Remove(blog);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            Blog blog = await _blogService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();

            BlogEditVM model = new()
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                blogImages = blog.BlogImages
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BlogEditVM updatedProduct)
        {
            if (!ModelState.IsValid) return View(updatedProduct);

            Blog dbProduct = await _blogService.GetByIdAsync((int)id);

            if (dbProduct is null) return NotFound();

            if (updatedProduct.Photos != null)
            {

                foreach (var photo in updatedProduct.Photos)
                {

                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View(dbProduct);
                    }

                    if (!photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View(dbProduct);
                    }


                }

                foreach (var item in dbProduct.BlogImages)
                {

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/blog", item.Image);

                    FileHelper.DeleteFile(path);
                }


                List<BlogImage> productImages = new();

                foreach (var photo in updatedProduct.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;


                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/img/blog", fileName);

                    await FileHelper.SaveFileAsync(path, photo);


                    BlogImage productImage = new()
                    {
                        Image = fileName
                    };

                    productImages.Add(productImage);

                }

                productImages.FirstOrDefault().IsMain = true;

                dbProduct.BlogImages = productImages;
            }

            dbProduct.Title = updatedProduct.Title;

            dbProduct.Description = updatedProduct.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}

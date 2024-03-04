using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestBlog.Models;

namespace TestBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDbContext blogDbContext;

        public BlogController(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public IActionResult Index()
        {
            var blogs = blogDbContext.Blogs.Include(b=>b.Category).ToList();
            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> categoriesList = new List<SelectListItem>();
            List<Category> categories = await blogDbContext.Categories.ToListAsync();

            foreach (var category in categories)
            {
                categoriesList.Add(new SelectListItem() { Text = category.Name, Value = category.Id.ToString() });
            }

            ViewBag.Categories = categoriesList;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            var data = new Blog()
            {
                Title = blog.Title,
                Intro = blog.Intro,
                Body = blog.Body,
                CategoryId = blog.CategoryId,
            };

            await blogDbContext.AddAsync(data);
            await blogDbContext.SaveChangesAsync();

            return Redirect("/");
        }
    }
}

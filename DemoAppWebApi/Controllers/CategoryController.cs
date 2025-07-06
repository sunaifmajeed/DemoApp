using DemoAppDataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly QuickKartDbContext _context;

        public CategoryController(QuickKartDbContext context)
        {
            _context = context;
        }

        // Example method to get all categories
        [HttpGet("GetAllCategories")]
        public async Task<List<Category>> GetAllCategories()
        {
            var categories = new List<Category>();
            try
            {
                categories = await _context.Categories.ToListAsync();
            }
            catch (Exception)
            {
                categories = null;
            }
            return categories;
        }
    }
}

using DemoAppDataAccessLayer.InterFaces;
using DemoAppDataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Outlook;
using Category = DemoAppDataAccessLayer.Models.Category;

namespace DemoAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryRepo;

        public CategoryController(ICategory category)
        {
            _categoryRepo = category;
        }

        // Example method to get all categories
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = new List<Category>();
            try
            {
                categories = await _categoryRepo.GetAllCategories();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "An error occurred while retrieving categories."); 
            }
            return Ok(categories);
        }
    }
}

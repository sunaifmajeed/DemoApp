using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoAppDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Outlook;

namespace DemoAppDataAccessLayer.QuickKartRepository
{
    public class QuickKartRepo
    {
        private readonly QuickKartDbContext _context;
        public QuickKartRepo(QuickKartDbContext context)
        {
            _context = context;
        }
        // Example method to get all categories

        public async Task<List<Models.Category>> GetAllCategories()
        {
            var categories = new List<Models.Category>();
            try
            {
                
                categories = await _context.Categories.ToListAsync();
            }
            catch (System.Exception)
            {

                categories = null;
            }
            return categories;
        }
    }
        
}

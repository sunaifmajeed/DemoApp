﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoAppDataAccessLayer.InterFaces;
using DemoAppDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Outlook;

namespace DemoAppDataAccessLayer.QuickKartRepository
{
    public class CategoryRepo : ICategory
    {
        private readonly QuickKartDbContext _context;
        public CategoryRepo(QuickKartDbContext context)
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

        public async Task<bool> UpdateCategory(Models.Category category)
        {
            try
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> AddCategory(Models.Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteCategory(int categoryId)
        {
            try
            {
                var category = await _context.Categories.FindAsync(categoryId);
                if (category == null)
                {
                    return false; // Category not found
                }
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}

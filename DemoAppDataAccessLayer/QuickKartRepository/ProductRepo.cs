using DemoAppDataAccessLayer.InterFaces;
using DemoAppDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppDataAccessLayer.QuickKartRepository
{
    public class ProductRepo : IProduct
    {

        private readonly QuickKartDbContext _context;
        public ProductRepo(QuickKartDbContext context)
        {
            _context = context;
        }
        // Example method to get all products
        public async Task<List<Models.Product>> GetAllProducts()
        {
            var products = new List<Models.Product>();
            try
            {
                products = await _context.Products.ToListAsync();
            }
            catch (System.Exception)
            {
                products = null;
            }
            return products;
        }
        public async Task<bool> UpdateProduct(Models.Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> AddProduct(Models.Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                {
                    return false; // Product not found
                }
                _context.Products.Remove(product);
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
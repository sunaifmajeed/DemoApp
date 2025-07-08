using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoAppDataAccessLayer.Models;

namespace DemoAppDataAccessLayer.InterFaces
{
    public interface ICategory
    {
         Task<List<Category>> GetAllCategories();
            Task<bool> UpdateCategory(Category category);
            Task<bool> AddCategory(Category category);
            Task<bool> DeleteCategory(int categoryId);
    }
}

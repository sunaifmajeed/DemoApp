using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppDataAccessLayer.InterFaces
{
    public interface IProduct
    {
        Task<List<Models.Product>> GetAllProducts();
        Task<bool> UpdateProduct(Models.Product product);
        Task<bool> AddProduct(Models.Product product);
        Task<bool> DeleteProduct(int productId);
    }
}

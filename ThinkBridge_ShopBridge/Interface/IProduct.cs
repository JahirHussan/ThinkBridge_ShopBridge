using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBridge_ShopBridge.Models;

namespace ThinkBridge_ShopBridge.Interface
{
    public interface IProduct
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products> GetProductByID(int productID);
        Task<int> CreateProduct(Products products);
        Task<bool> UpdateProduct(int productID,Products products);
        Task<bool> DeleteProduct(int productID);
        bool CheckProductName(string productName);
    }
}

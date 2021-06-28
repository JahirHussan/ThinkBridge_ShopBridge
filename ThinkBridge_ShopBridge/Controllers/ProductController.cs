using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using ThinkBridge_ShopBridge.Interface;
using ThinkBridge_ShopBridge.Models;
using ThinkBridge_ShopBridge.Repository;

namespace ThinkBridge_ShopBridge.Controllers
{
    public class ProductController : ApiController
    {
        public IProduct product;

        public ProductController()
        {
            this.product = new ProductRepository();
        }

        public ProductController(IProduct product)
        {
            this.product = product
            ?? throw new ArgumentNullException(nameof(product));
        }

        [HttpGet]
        [Route("api/GetProducts")]

        public async Task<IEnumerable<Products>> GetProducts()
        {
            try
            {
                IEnumerable<Products> products = null;

                products = await product.GetProducts();

                if (!products.Any())
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No products found")),
                        ReasonPhrase = "No products found"
                    };
                    throw new HttpResponseException(response);
                }

                return products;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("api/GetProductByID/{ProductID}")]
        public async Task<Products> GetProductByID(int ProductID)
        {
            Products products = null;
            try
            {
                products = await product.GetProductByID(ProductID);

                if (products.ProductID == null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No products found with productid={0}",ProductID)),
                        ReasonPhrase = "No products found"
                    };
                    throw new HttpResponseException(response);
                }               
            }
            catch (Exception ex)
            {
                throw;
            }
            return products;
        }

        [HttpPost]
        [Route("api/CrateProduct")]

        public async Task<int> CrateProduct(Products ProductDetails)
        {
            try
            {
                ModelStateDictionary ms;

                if (!isProductvaild(ProductDetails, false, out ms))
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ms));
                }
                else
                {
                    return await product.CreateProduct(ProductDetails);
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }            
        }

        [HttpPut]
        [Route("api/UpdateProduct/{productId}")]

        public async Task<bool> UpdateProduct(int ProductId, Products ProductDetails)
        {
            try
            {
                ModelStateDictionary ms;

                if (!isProductvaild(ProductDetails, true, out ms))
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ms));
                }
                else
                {
                    return await product.UpdateProduct(ProductId, ProductDetails);
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }            
        }

        [HttpDelete]
        [Route("api/DeleteProducts/{ProductID}")]

        public async Task<bool> DeleteProducts(int ProductID)
        {
            try
            {
                return await product.DeleteProduct(ProductID);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        private bool isProductvaild(Products productDetails, bool isUpdate, out ModelStateDictionary ms)
        {
            bool result = true;
            ms = new ModelStateDictionary();

            if (!isUpdate)
            {
                bool isDuplicate = false;

                isDuplicate = product.CheckProductName(productDetails.Name);

                if (isDuplicate == true)
                {
                    { ms.AddModelError("product.Name", "Product name is duplicated"); }
                }
            }
            if (string.IsNullOrEmpty(productDetails.Name)) { ms.AddModelError("product.Name", "Product name is required"); }
            if (string.IsNullOrEmpty(productDetails.Description)) { ms.AddModelError("product.Name", "Product description is required"); }
            if (string.IsNullOrEmpty(productDetails.SupplierName)) { ms.AddModelError("product.Name", "Product supplier name is required"); }
            if (productDetails.ProductPrice <= 0) { ms.AddModelError("product.Name", "Product Price should be greater than 0"); }

            if (ms.Count > 0) result = false;
            return result;
        }
    }
}

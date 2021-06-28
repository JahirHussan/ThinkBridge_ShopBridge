using CommonDLL;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ThinkBridge_ShopBridge.Interface;
using ThinkBridge_ShopBridge.Models;

namespace ThinkBridge_ShopBridge.Repository
{
    public class ProductRepository : BaseClass, IProduct
    {
        readonly DataAccess dataAccess = null;

        public ProductRepository()
        {
            dataAccess = new DataAccess(GetConnectionstring());
        }

        public bool CheckProductName(string productName)
        {
            int outValue = 0;
            bool result = false;
            SqlConnection connection = OpenConnection();
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[CheckProductName]";
                command.Parameters.Add(new SqlParameter("@ProductName", productName));

                var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                outValue = (int)returnParameter.Value;
                if (outValue == 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(connection); }

            return result;
        }

        public Task<int> CreateProduct(Products products)
        {
            if (products == null)
            {
                return null;
            }
            int ProductId = 0;

            SqlConnection connection = OpenConnection();
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[CreateProducts]";

                command.Parameters.Add(new SqlParameter("ProductName", products.Name));
                command.Parameters.Add(new SqlParameter("ProductDescription", products.Description));
                command.Parameters.Add(new SqlParameter("ProductPrice", products.ProductPrice));
                command.Parameters.Add(new SqlParameter("SupplierName", products.SupplierName));
                command.Parameters.Add(new SqlParameter("ImageURL", products.ImageURL));

                SqlParameter productID = command.Parameters.Add(new SqlParameter("ProductID", SqlDbType.Int));
                productID.Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                ProductId = Convert.IsDBNull(productID.Value) ? 0 : (int)productID.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(connection); }

            return Task.FromResult(ProductId);
        }

        public async Task<bool> DeleteProduct(int productID)
        {
            int outValue = 0;
            bool result = false;
            SqlConnection connection = OpenConnection();
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[DeleteProduct]";
                command.Parameters.Add(new SqlParameter("ProductID", productID));

                var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                outValue = (int)returnParameter.Value;
                if (outValue == 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(connection); }

            return await Task.FromResult(result);
        }

        public async Task<Products> GetProductByID(int productID)
        {
            Products product = new Products();
            SqlConnection connection = OpenConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[GetProductByID]";
                command.Parameters.Add(new SqlParameter("ProductID", productID));
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.TableMappings.Add("Table", "Products");
                da.Fill(ds);

                if (ds.Tables["Products"] != null && ds.Tables["Products"].Rows.Count>0)
                {
                    foreach (DataRow dr in ds.Tables["Products"].Rows)
                    {
                        product = new Products
                        {
                            ProductID = (int)dr["ProductID"],
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            ProductPrice = (decimal)dr["ProductPrice"],
                            SupplierName = dr["SupplierName"].ToString(),
                            ImageURL = dr["ImageURL"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { CloseConnection(connection); }

            return await Task.FromResult(product);
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            List<Products> products = new List<Products>();
            SqlConnection connection = OpenConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[GetProductsList]";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.TableMappings.Add("Table", "Products");
                da.Fill(ds);
                Products product;
                if (ds.Tables["Products"] != null && ds.Tables["Products"].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables["Products"].Rows)
                    {
                        product = new Products
                        {
                            ProductID = (int)dr["ProductID"],
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            ProductPrice = (decimal)dr["ProductPrice"],
                            SupplierName = dr["SupplierName"].ToString(),
                            ImageURL = dr["ImageURL"].ToString()
                        };
                        products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { CloseConnection(connection); }

            return await Task.FromResult(products);
        }

        public async Task<bool> UpdateProduct(int productID, Products products)
        {
            if (products == null)
            {
                return false;
            }
            int outValue = 0;
            bool ret = false;

            SqlConnection connection = OpenConnection();
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[UpdateProduct]";

                command.Parameters.Add(new SqlParameter("ProductID", productID));
                command.Parameters.Add(new SqlParameter("ProductName", products.Name));
                command.Parameters.Add(new SqlParameter("ProductDescription", products.Description));
                command.Parameters.Add(new SqlParameter("ProductPrice", products.ProductPrice));
                command.Parameters.Add(new SqlParameter("SupplierName", products.SupplierName));
                command.Parameters.Add(new SqlParameter("ImageURL", products.ImageURL));
                int outvalue = command.ExecuteNonQuery();

                if (outValue == 0)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(connection); }

            return await Task.FromResult(ret);
        }
    }
}
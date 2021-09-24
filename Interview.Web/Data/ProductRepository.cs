using Interview.Web.Common;
using Interview.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly IAppSettings _appSettings;
        public ProductRepository(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public async Task<bool> AddProduct(Product p)
        {
            using (var con = new SqlConnection(_appSettings.InventoryConnectionString))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [Instances].[Products]
                                                (Name, 
                                                Description, 
                                                ProductImageUris, 
                                                ValidSkus, 
                                                CreatedTimestamp) OUTPUT INSERTED.InstanceId
                                             Values
                                                (@Name, 
                                                @Description, 
                                                @ProductImageUris, 
                                                @ValidSkus, 
                                                @CreatedTimestamp)";
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar)).Value = p.Name;
                    cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar)).Value = p.Description;
                    cmd.Parameters.Add(new SqlParameter("@ProductImageUris", SqlDbType.NVarChar)).Value = p.ProductImageUris;
                    cmd.Parameters.Add(new SqlParameter("@ValidSkus", SqlDbType.NVarChar)).Value = p.ValidSkus;
                    cmd.Parameters.Add(new SqlParameter("@CreatedTimestamp", SqlDbType.DateTime)).Value = p.CreatedTimestamp;
                    await con.OpenAsync();
                    p.InstanceId = await cmd.ExecuteScalarAsync() as int?;
                }
            }
            return p.InstanceId.HasValue && p.InstanceId.Value >0;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = new List<Product>();
            using(var con = new SqlConnection(_appSettings.InventoryConnectionString))
            {
                using(var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"SELECT InstanceId, 
                                                Name, 
                                                Description, 
                                                ProductImageUris, 
                                                ValidSkus, 
                                                CreatedTimestamp 
                                                FROM [Instances].[Products]";
                    await con.OpenAsync();
                    using(var dr = await cmd.ExecuteReaderAsync())
                    {
                        while(await dr.ReadAsync())
                        {
                            var p = new Product();
                            p.InstanceId = dr["InstanceId"] as int? ?? 0;
                            p.Name = dr["Name"] as string ?? string.Empty;
                            p.Description = dr["Description"] as string ?? string.Empty;
                            p.ProductImageUris = dr["ProductImageUris"] as string ?? string.Empty;
                            p.ValidSkus = dr["ValidSkus"] as string ?? string.Empty;
                            p.CreatedTimestamp = dr["CreatedTimestamp"] as DateTime? ?? DateTime.MinValue;
                            products.Add(p);
                        }
                    }
                }
            }
            return products;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BiddingSystem.Common;
using BiddingSystem.Entities;
using BiddingSystem.Repository.Contracts;

namespace BiddingSystem.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly ILogger<ProductRepository> logger;
        public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger) : base(configuration)
        {
            this.logger = logger;
        }

        public int GetCompanyID(int productID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    string sql = "select companyid from product where id = @productID";
                    return con.Query<int>(sql, new { productID = productID }).FirstOrDefault();
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get product companyid for id", new { contact = JsonConvert.SerializeObject(productID) });
                    return 0;
                }
            }
        }

        public Product GetForCompany(int productID, int companyID)
        {
            using (IDbConnection con = CreateConnection())
            {
                List<Bid> bids = new List<Bid>();

                try
                {
                    string sql = @"select prod.*, b.* from product as prod
                    left join bid as b
                    on prod.id = b.productid and b.companyid = @companyid and b.cancelled = false
                    where prod.id = @productID";

                    Product product = con.Query<Product, Bid, Product>(sql, (productObject, bid) =>
                    {
                        if (bid != null)
                        {
                            bids.Add(bid);
                        }
                        return productObject;
                    }, new { companyID = companyID, productID = productID }).FirstOrDefault();
                    product.bids = bids;
                    return product;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get product for id", new { contact = JsonConvert.SerializeObject(productID) });
                    return null;
                }
            }
        }

        public Product GetForCreator(int productID)
        {
            using (IDbConnection con = CreateConnection())
            {
                List<Bid> bids = new List<Bid>();

                try
                {
                    string sql = @"select prod.*, b.*, bcmpy.id, bcmpy.companyname from product as prod
                    left join bid as b
                    on prod.id = b.productid and b.cancelled = false  
                    left join company as bcmpy
                    on b.companyid = bcmpy.id 
                    where prod.id = @productID";

                    Product product = con.Query<Product, Bid, Company, Product>(sql, (productObject, bid, company) =>
                    {
                        if (bid != null)
                        {
                            bid.company = company;
                            bids.Add(bid);
                        }
                        return productObject;
                    }, new { productID = productID }).FirstOrDefault();

                    product.bids = bids;
                    return product;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get product for id", new { contact = JsonConvert.SerializeObject(productID) });
                    return null;
                }
            }
        }

        public IEnumerable<Product> GetByCompanyID(int companyID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    string sql = @"select * from product
                    where companyid = @companyID and cancelled is false";
                    IEnumerable<Product> products = con.Query<Product>(sql, new { companyID = companyID }).Distinct();
                    return products;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to get products for company with id", new { contact = JsonConvert.SerializeObject(companyID) });
                    return null;
                }
            }
        }

        public (int ProductID, DatabaseCode DbCode) Insert(Product product)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int productID = Convert.ToInt32(con.Insert<Product>(product));
                    return (productID, DatabaseCode.Inserted);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to insert new product", new { contact = JsonConvert.SerializeObject(product) });
                    return (0, DatabaseCode.Error);
                }
            }
        }

        public bool Cancel(int productID)
        {
            string sql = "update product set cancelled = true where id = @productID";
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    return con.Execute(sql, new { productID = productID }) == 1;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to cancel product", new { contact = JsonConvert.SerializeObject(productID) });
                    return false;
                }
            }
        }

        public bool IsProductCreatedByUser(Guid userID, int productID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    int row = con.QueryFirstOrDefault<int>("select count(*) from product where id = @productID and userid = @userID", new { productID = productID, userID });
                    return row == 1;
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to cancel product", new { contact = JsonConvert.SerializeObject(productID) });
                    return false;
                }
            }
        }

        public Guid GetProductCreatorID(int productID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    return con.QueryFirstOrDefault<Guid>("select userid from product where id = @productID", new { productID = productID });
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to cancel product", new { contact = JsonConvert.SerializeObject(productID) });
                    return Guid.Empty;
                }
            }
        }

        public Product GetProduct(int productID)
        {
            using (IDbConnection con = CreateConnection())
            {
                try
                {
                    return con.QueryFirstOrDefault<Product>("select * from product where id = @productID", new { productID = productID });
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Failed to cancel product", new { contact = JsonConvert.SerializeObject(productID) });
                    return null;
                }
            }
        }

        public IEnumerable<Product> GetNewProducts(int companyIDToExclude)
        {
            using (IDbConnection con = CreateConnection())
            {
                List<Bid> bids = new List<Bid>();

                try
                {
                    string sql = @"select prod.* from product as prod                    
                    where prod.companyid <> @companyIDToExclude and enddate >= @endDate and cancelled = false";

                    IEnumerable<Product> products = con.Query<Product>(sql, new { companyIDToExclude = companyIDToExclude, endDate = DateTime.Now });

                    return products;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
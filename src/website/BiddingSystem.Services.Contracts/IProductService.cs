using System;
using System.Collections.Generic;
using BiddingSystem.Common;
using BiddingSystem.Models.Bid;
using BiddingSystem.Models.Product;

namespace BiddingSystem.Services.Contracts
{
    public interface IProductService
    {
        (int productID, DatabaseCode DbCode) CreateProduct(ProductModel product, string userName);
        (bool viewable, ProductModel product) View(int productID, string userName);
        List<ProductModel> GetByCompanyID(int companyID);
        bool Cancel(int productID);
        bool IsProductCreatedByUser(Guid userID, int productID);
        Guid GetProductCreatorID(int productID);
        ProductModel GetProduct(int productID);
        List<ProductModel> GetNewProducts(int companyIDToExclude);
    }
}
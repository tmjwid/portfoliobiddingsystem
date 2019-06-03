using System;
using System.Collections.Generic;
using BiddingSystem.Common;
using BiddingSystem.Entities;

namespace BiddingSystem.Repository.Contracts
{
    public interface IProductRepository
    {
        Product GetForCompany(int productID, int companyID);
        Product GetForCreator(int productID);
        (int ProductID, DatabaseCode DbCode) Insert(Product product);
        IEnumerable<Product> GetByCompanyID(int companyID);
        bool Cancel(int productID);
        int GetCompanyID(int productID);
        bool IsProductCreatedByUser(Guid userID, int productID);
        Guid GetProductCreatorID(int productID);
        Product GetProduct(int productID);
        IEnumerable<Product> GetNewProducts(int companyIDToExclude);
    }
}
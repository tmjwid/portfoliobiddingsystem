using System.Collections.Generic;
using BiddingSystem.Entities;
using BiddingSystem.Models.Account;
using BiddingSystem.Models.Product;

namespace BiddingSystem.DTOMapper.Contracts
{
    public interface IProductMapper
    {
        Product ToEntity(ProductModel productModel);
        ProductModel ToModel(Product product);
        List<ProductModel> ToModelList(IEnumerable<Product> products);
    }
}
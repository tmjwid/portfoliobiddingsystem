using System.Collections.Generic;
using System.Linq;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Entities;
using BiddingSystem.Models.Account;
using BiddingSystem.Models.Product;

namespace BiddingSystem.DTOMapper
{
    public class ProductMapper : IProductMapper
    {
        private readonly IBidMapper bidMapper;
        private readonly INotificationMapper notificationMapper;
        public ProductMapper(IBidMapper bidMapper, INotificationMapper productUpdateMapper)
        {
            this.bidMapper = bidMapper;
            this.notificationMapper = productUpdateMapper;
        }

        public Product ToEntity(ProductModel productModel)
        {
            if (productModel == null)
            {
                return null;
            }
            Product product = new Product();
            product.companyid = productModel.CompanyID;
            product.cost = productModel.Cost;
            product.datecreated = productModel.DateCreated;
            product.description = productModel.Description;
            product.enddate = productModel.EndDate;
            product.id = productModel.ID;
            product.reference = productModel.Reference;
            product.title = productModel.Title;
            product.userid = productModel.UserID;
            return product;
        }

        public ProductModel ToModel(Product product)
        {
            if (product == null)
            {
                return null;
            }
            ProductModel productModel = new ProductModel();
            productModel.CompanyID = product.companyid;
            productModel.Cost = product.cost;
            productModel.DateCreated = product.datecreated;
            productModel.Description = product.description;
            productModel.EndDate = product.enddate;
            productModel.ID = product.id;
            productModel.Reference = product.reference;
            productModel.Title = product.title;
            productModel.UserID = product.userid;
            productModel.Bids = product.bids != null ? bidMapper.ToModelList(product.bids) : null;
            productModel.ProductUpdates = product.productupdates != null ? notificationMapper.ToModelList(product.productupdates) : null;
            return productModel;
        }

        public List<ProductModel> ToModelList(IEnumerable<Product> products)
        {
            List<ProductModel> list = new List<ProductModel>();
            if (products != null && products.Any())
            {
                list.AddRange(products.Select(e => ToModel(e)));
            }
            return list;
        }
    }
}
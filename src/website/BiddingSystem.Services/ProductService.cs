using System;
using System.Collections.Generic;
using BiddingSystem.Common;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Models.Bid;
using BiddingSystem.Models.Product;
using BiddingSystem.Repository.Contracts;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Services
{
    public class productService : IProductService
    {
        private readonly ICompanyService companyService;
        private readonly IProductRepository productRepository;
        private readonly IProductMapper productMapper;
        private readonly IUserService userService;

        public productService(IProductRepository productRepository, IProductMapper productMapper, ICompanyService companyService,
        IUserService userService)
        {
            this.productRepository = productRepository;
            this.productMapper = productMapper;
            this.companyService = companyService;
            this.userService = userService;
        }

        public bool Cancel(int productID)
        {
            return productRepository.Cancel(productID);
        }

        public (int productID, DatabaseCode DbCode) CreateProduct(ProductModel product, string userName)
        {
            product.DateCreated = DateTime.Now;
            product.CompanyID = companyService.GetCompanyIDByUserUsername(userName);
            product.UserID = userService.GetUserID(userName);
            return productRepository.Insert(productMapper.ToEntity(product));
        }

        public List<ProductModel> GetByCompanyID(int companyID)
        {
            return productMapper.ToModelList(productRepository.GetByCompanyID(companyID));
        }

        public List<ProductModel> GetNewProducts(int companyIDToExclude)
        {
            return productMapper.ToModelList(productRepository.GetNewProducts(companyIDToExclude));
        }

        public ProductModel GetProduct(int productID)
        {
            return productMapper.ToModel(productRepository.GetProduct(productID));
        }

        public Guid GetProductCreatorID(int productID)
        {
            return productRepository.GetProductCreatorID(productID);
        }

        public bool IsProductCreatedByUser(Guid userID, int productID)
        {
            return productRepository.IsProductCreatedByUser(userID, productID);
        }

        public (bool viewable, ProductModel product) View(int productID, string userName)
        {
            (Guid userID, int companyID) details = userService.GetUserAndCompanyID(userName);
            int companyIDForProduct = productRepository.GetCompanyID(productID);
            ProductModel product;

            //check to see if the company that made the product is the one requesting the product
            if (companyIDForProduct == details.companyID)
            {
                product = productMapper.ToModel(productRepository.GetForCreator(productID));
                product.Editable = product.UserID == details.userID;
            }
            else
            {
                product = productMapper.ToModel(productRepository.GetForCompany(productID, details.companyID));
            }

            return (true, product);
        }
    }
}
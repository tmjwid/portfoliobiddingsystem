using System;
using BiddingSystem.Common;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Models.Account;
using BiddingSystem.Models;
using BiddingSystem.Repository.Contracts;
using BiddingSystem.Services.Contracts;
using BiddingSystem.Models.Bid;
using Newtonsoft.Json;
using System.Collections.Generic;
using BiddingSystem.Entities;
using BiddingSystem.Models.Product;
using System.Linq;

namespace BiddingSystem.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository bidRepository;
        private readonly IBidMapper bidMapper;
        private readonly IUserService userService;
        private readonly INotificationService notificationService;
        private readonly IProductService productService;

        public BidService(IBidRepository bidRepository, IBidMapper bidMapper, IUserService userService, INotificationService productUpdateService,
        IProductService productService)
        {
            this.bidRepository = bidRepository;
            this.bidMapper = bidMapper;
            this.userService = userService;
            this.notificationService = productUpdateService;
            this.productService = productService;
        }

        public DatabaseCode AcceptBid(int bidID, Guid userID)
        {
            int productID = bidRepository.GetProductIDForBid(bidID);
            ProductModel product = productService.GetProduct(productID);

            if (productService.IsProductCreatedByUser(userID, productID))
            {
                var bidAcceptedResult = bidRepository.AcceptBid(bidID);

                if (bidAcceptedResult.dbCode == DatabaseCode.Updated)
                {
                    notificationService.Insert(new NotificationModel()
                    {
                        Information = string.Format("Your bid for product {0} has been accepted! You will be contacted shortly by the seller.", product.ReferenceForView),
                        ReceivingUserID = bidAcceptedResult.userID,
                        AdditionalInformation = JsonConvert.SerializeObject(new { productID })
                    });

                    (List<Bid> list, DatabaseCode dbCode) bidsRejected = bidRepository.DeclineBidsForProduct(userID, bidID, productID);

                    if (bidsRejected.dbCode == DatabaseCode.Updated)
                    {
                        foreach (var item in bidsRejected.list)
                        {
                            notificationService.Insert(new NotificationModel()
                            {
                                Information = string.Format("Your bid for product {0} has been declined and the product has been awarded.", product.ReferenceForView),
                                ReceivingUserID = item.userid,
                                AdditionalInformation = JsonConvert.SerializeObject(new { productID, bidID = item.id })
                            });
                        }
                    }

                    return bidsRejected.dbCode;
                }
                return DatabaseCode.Error;
            }
            return DatabaseCode.NotAllowed;
        }

        public (int productID, DatabaseCode dbCode) DeclineBid(int bidID, Guid userID)
        {
            int productID = bidRepository.GetProductIDForBid(bidID);
            if (productService.IsProductCreatedByUser(userID, productID))
            {
                var bidDecliend = bidRepository.DeclineBid(bidID);
                if (bidDecliend.dbCode == DatabaseCode.Updated)
                {
                    (int productUpdateid, DatabaseCode dbCode) notification = notificationService.Insert(new NotificationModel()
                    {
                        DueDate = DateTime.Now.AddDays(3).Date,
                        Information = "Bid has been declined",
                        ReceivingUserID = bidDecliend.userID,
                        AdditionalInformation = JsonConvert.SerializeObject(new { productID, bidID })
                    });
                    return (productID, notification.dbCode);
                }
            }
            return (productID, DatabaseCode.NotAllowed);
        }

        public DatabaseCode CancelBid(int bidID, Guid userID)
        {
            if (bidRepository.DoesBidBelongToUser(bidID, userID))
            {
                return bidRepository.CancelBid(bidID, userID);
            }
            return DatabaseCode.NotAllowed;
        }

        public bool PlaceBid(BidModel bid, string username)
        {
            UserModel user = userService.GetUser(username);
            bid.UserID = user.ID;
            bid.CompanyID = user.CompanyID;
            ProductModel product = productService.GetProduct(bid.ProductID);

            bool bidSuccessful = bidRepository.PlaceBid(bidMapper.ToEntity(bid));
            if (bidSuccessful)
            {
                (int productUpdateid, DatabaseCode dbCOde) notification = notificationService.Insert(new NotificationModel()
                {
                    DueDate = DateTime.Now.AddDays(3).Date,
                    Information = "Bid has been placed by " + user.Company.CompanyName + " on product " + product.ReferenceForView,
                    ReceivingUserID = product.UserID,
                    AdditionalInformation = bid.ProductID.ToString()
                });
                return notification.dbCOde == DatabaseCode.Inserted;
            }
            return bidSuccessful;
        }
    }
}
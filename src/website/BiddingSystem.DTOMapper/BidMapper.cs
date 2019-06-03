using System.Collections.Generic;
using System.Linq;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Entities;
using BiddingSystem.Models.Bid;

namespace BiddingSystem.DTOMapper
{
    public class BidMapper : IBidMapper
    {
        public Bid ToEntity(BidModel bidModel)
        {
            Bid bid = new Bid();
            bid.id = bidModel.ID;
            bid.companyid = bidModel.CompanyID;
            bid.price = bidModel.Price;
            bid.productid = bidModel.ProductID;
            bid.userid = bidModel.UserID;
            return bid;
        }

        public BidModel ToModel(Bid bid)
        {
            BidModel bidModel = new BidModel();
            bidModel.ID = bid.id;
            bidModel.CompanyID = bid.companyid;
            bidModel.Price = bid.price;
            bidModel.ProductID = bid.productid;
            bidModel.UserID = bid.userid;
            //hack, fix if get full job
            bidModel.Company = bid.company != null ? new Models.Account.CompanyModel()
            {
                CompanyName = bid.company.companyname,
                ID = bid.company.id
                
            } : null;
            bidModel.Declined = bid.declined;
            bidModel.Accepted = bid.accepted;
            bidModel.Cancelled = bid.cancelled;
            return bidModel;
        }

        public List<BidModel> ToModelList(IEnumerable<Bid> bids)
        {
            List<BidModel> list = new List<BidModel>();
            if (bids.Any())
            {
                list.AddRange(bids.Select(e => ToModel(e)));
            }
            return list;
        }
    }
}
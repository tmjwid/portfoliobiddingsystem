using System;
using BiddingSystem.Common;
using BiddingSystem.Models.Bid;

namespace BiddingSystem.Services.Contracts
{
    public interface IBidService
    {
        DatabaseCode AcceptBid(int bidID, Guid userID);
        (int productID, DatabaseCode dbCode) DeclineBid(int bidID, Guid userID);
        bool PlaceBid(BidModel bid, string username);
        DatabaseCode CancelBid(int bidID, Guid userID);
    }
}
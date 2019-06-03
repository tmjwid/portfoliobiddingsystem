using System;
using System.Collections.Generic;
using BiddingSystem.Common;
using BiddingSystem.Entities;

namespace BiddingSystem.Repository.Contracts
{
    public interface IBidRepository
    {
        (Guid userID, DatabaseCode dbCode) AcceptBid(int bidID);
        (Guid userID, DatabaseCode dbCode) DeclineBid(int bidID);
        bool DoesBidBelongToUser(int bidID, Guid userID);
        bool PlaceBid(Bid bid);
        DatabaseCode CancelBid(int bidID, Guid userID);
        int GetProductIDForBid(int bidID);
        (List<Bid> bidsRejected, DatabaseCode dbCode) DeclineBidsForProduct(Guid winningUserID, int bidID, int productID);
    }
}
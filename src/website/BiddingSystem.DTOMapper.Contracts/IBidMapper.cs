using System.Collections.Generic;
using BiddingSystem.Entities;
using BiddingSystem.Models.Bid;

namespace BiddingSystem.DTOMapper.Contracts
{
    public interface IBidMapper
    {
        Bid ToEntity(BidModel bidModel);
        BidModel ToModel(Bid bid);
        List<BidModel> ToModelList(IEnumerable<Bid> bids);
    }
}
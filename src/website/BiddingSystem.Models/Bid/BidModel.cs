using System;
using BiddingSystem.Models.Account;

namespace BiddingSystem.Models.Bid
{
    public class BidModel
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public int ProductID { get; set; }
        public int CompanyID { get; set; }
        public Guid UserID { get; set; }
        public CompanyModel Company { get; set; }
        public bool Accepted { get; set; }
        public bool Declined { get; set; }
        public bool Cancelled { get; set; }
    }
}
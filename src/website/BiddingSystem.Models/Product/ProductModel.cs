using System;
using System.Collections.Generic;
using BiddingSystem.Models.Bid;
using BiddingSystem.Models.Company;

namespace BiddingSystem.Models.Product
{
    public class ProductModel
    {
        public int ID { get; set; }
        public int Reference { get; set; }
        public string ReferenceForView
        {
            get { return "#" + Reference.ToString("D8"); }
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompanyID { get; set; }
        public Guid UserID { get; set; }
        public int Cost { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EndDate { get; set; }
        public List<NotificationModel> ProductUpdates { get; set; }
        public List<ProductDocumentModel> ProductDocuments { get; set; }
        public bool Editable { get; set; }
        public bool Cancelled { get; set; }
        public List<BidModel> Bids { get; set; }
    }
}
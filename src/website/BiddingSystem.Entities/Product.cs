using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace BiddingSystem.Entities
{
    [Table("product")]
    public class Product
    {

        [Key]
        public int id { get; set; }
        [Computed]
        public int reference { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int companyid { get; set; }
        public Guid userid { get; set; }
        public int cost { get; set; }
        public DateTime datecreated { get; set; }
        public DateTime enddate { get; set; }
        [Computed]
        public int[] subcontractorids { get; set; }
        public bool cancelled { get; set; }
        [Computed]
        public List<Notification> productupdates { get; set; }
        [Computed]
        public List<Bid> bids { get; set; }
    }
}
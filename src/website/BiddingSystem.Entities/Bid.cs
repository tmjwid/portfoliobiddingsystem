using System;
using Dapper.Contrib.Extensions;

namespace BiddingSystem.Entities
{
    [Table("bid")]
    public class Bid
    {
        [Key]
        public int id { get; set; }
        public decimal price { get; set; }
        public int productid { get; set; }
        public int companyid { get; set; }
        public Guid userid { get; set; }
        public bool accepted { get; set; }
        public bool declined { get; set; }
        
        [Computed]
        public Company company { get; set; }
        public bool cancelled { get; set; }
    }
}
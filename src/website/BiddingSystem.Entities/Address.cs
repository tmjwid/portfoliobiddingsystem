using System;
using Dapper.Contrib.Extensions;

namespace BiddingSystem.Entities
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int id { get; set; }
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string county { get; set; }
        public string postcode { get; set; }
        //fk
        public Guid userid { get; set; }
        public int companyid { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using Dapper.Contrib.Extensions;

namespace BiddingSystem.Entities
{
    [Table("users")]
    public class User
    {

        [ExplicitKey]
        public Guid id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int companyid { get; set; }

        [Computed]
        public Company company { get; set; }
        [Computed]
        public Contact contact { get; set; }
        [Computed]
        public Address address { get; set; }
        [Computed]
        public List<Product> products{ get; set; }

    }
}

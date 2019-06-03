using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace BiddingSystem.Entities
{
    [Table("company")]
    public class Company
    {

        public int id { get; set; }
        public int companynumber { get; set; }
        public string companyname { get; set; }
        public int companytypeid { get; set; }
        public int companyfunctionid { get; set; }
        public string logourl { get; set; }
        
        [Computed]
        public int[] subcontactors { get; set; }

        //objects
        [Computed]
        public Address companyaddress { get; set; }
        
        [Computed]
        public Contact contact { get; set; }
        
        [Computed]
        public List<Product> products { get; set; }
        [Computed]
        public CompanyFunction companyfunction { get; set; }
    }
}
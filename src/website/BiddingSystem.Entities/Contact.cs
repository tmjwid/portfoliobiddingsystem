using System;
using Dapper.Contrib.Extensions;

namespace BiddingSystem.Entities
{
    [Table("contact")]
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string jobtitle { get; set; }     
        public string phonenumber { get; set; }
        public string secondaryphonenumber { get; set; }

        //fk
        public Guid userid { get; set; }
        public int companyid { get; set; }
    }
}
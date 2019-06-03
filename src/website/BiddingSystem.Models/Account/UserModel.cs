using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BiddingSystem.Models.Bid;

namespace BiddingSystem.Models.Account
{
    public class UserModel : MessageViewModel
    {
        public Guid ID { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int CompanyID { get; set; }
        public CompanyModel Company { get; set; }
        public ContactModel Contact { get; set; }
    }
}

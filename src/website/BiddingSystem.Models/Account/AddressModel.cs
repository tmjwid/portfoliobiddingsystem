using System;
using System.ComponentModel.DataAnnotations;

namespace BiddingSystem.Models.Account
{
    public class AddressModel
    {
        public int ID { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string PostCode { get; set; }
        public Guid UserID { get; set; }
        public int CompanyID { get; set; }
    }
}
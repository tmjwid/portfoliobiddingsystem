using System;
using System.ComponentModel.DataAnnotations;

namespace BiddingSystem.Models.Account
{
    public class ContactModel
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "The Phone Number field is not a valid phone number.")]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "The Secondary Phone Number field is not a valid phone number.")]
        [Phone]
        public string SecondaryPhoneNumber { get; set; }
        public Guid UserID { get; set; }
        public int ContactID { get; set; }
        public int CompanyID { get; set; }
    }
}
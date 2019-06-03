using System.ComponentModel.DataAnnotations;
namespace BiddingSystem.Models.Account
{
    public class LoginModel : MessageViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
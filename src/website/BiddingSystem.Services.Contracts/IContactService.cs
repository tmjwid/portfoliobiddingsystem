using BiddingSystem.Common;
using BiddingSystem.Models.Account;

namespace BiddingSystem.Services.Contracts
{
    public interface IContactService
    {
        (int contactID, DatabaseCode dbCode) CreateContact(ContactModel contact);
    }
}
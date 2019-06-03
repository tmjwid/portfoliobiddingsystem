using BiddingSystem.Common;
using BiddingSystem.Models.Account;

namespace BiddingSystem.Services.Contracts
{
    public interface IAddressService
    {
         (int addressID, DatabaseCode dbCode) CreateAddress(AddressModel address);
    }
}
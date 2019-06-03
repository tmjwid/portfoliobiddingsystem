using BiddingSystem.Common;
using BiddingSystem.Entities;

namespace BiddingSystem.Repository.Contracts
{
    public interface IAddressRepository
    {
        (int addressID, DatabaseCode dbCode) Insert(Address address);
    }
}
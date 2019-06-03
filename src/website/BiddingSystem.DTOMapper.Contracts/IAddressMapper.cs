using BiddingSystem.Entities;
using BiddingSystem.Models.Account;

namespace BiddingSystem.DTOMapper.Contracts
{
    public interface IAddressMapper
    {
        Address ToEntity(AddressModel addressModel);
        AddressModel ToModel(Address address);
    }
}
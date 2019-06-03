using BiddingSystem.Common;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Models.Account;
using BiddingSystem.Repository.Contracts;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;
        private readonly IAddressMapper addressMapper;
        public AddressService(IAddressRepository addressRepository, IAddressMapper addressMapper)
        {
            this.addressRepository = addressRepository;
            this.addressMapper = addressMapper;
        }
        public (int addressID, DatabaseCode dbCode) CreateAddress(AddressModel address)
        {
            return addressRepository.Insert(addressMapper.ToEntity(address));
        }
    }
}
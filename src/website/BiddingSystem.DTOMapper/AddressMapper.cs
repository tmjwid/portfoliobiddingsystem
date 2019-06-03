using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Entities;
using BiddingSystem.Models.Account;

namespace BiddingSystem.DTOMapper
{
    public class AddressMapper : IAddressMapper
    {
        public Address ToEntity(AddressModel addressModel)
        {
            Address address = new Address();
            address.addressline1 = addressModel.AddressLine1;
            address.addressline2 = addressModel.AddressLine2;
            address.city = addressModel.City;
            address.country = addressModel.Country;
            address.county = addressModel.County;
            address.id = addressModel.ID;
            address.postcode = addressModel.PostCode;
            address.userid = addressModel.UserID;
            address.companyid = addressModel.CompanyID;
            return address;
        }

        public AddressModel ToModel(Address address)
        {
            AddressModel addressModel = new AddressModel();
            addressModel.AddressLine1 = address.addressline1;
            addressModel.AddressLine2 = address.addressline2;
            addressModel.City = address.city;
            addressModel.Country = address.country;
            addressModel.County = address.county;
            addressModel.ID = address.id;
            addressModel.PostCode = address.postcode;
            addressModel.UserID = address.userid;
            addressModel.CompanyID = address.companyid;
            return addressModel;
        }
    }
}
using BiddingSystem.Entities;
using BiddingSystem.Models.Account;

namespace BiddingSystem.DTOMapper.Contracts
{
    public interface IContactMapper
    {
         Contact ToEntity(ContactModel contactModel);
         ContactModel ToModel(Contact contact);

    }
}
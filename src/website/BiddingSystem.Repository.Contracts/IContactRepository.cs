using BiddingSystem.Common;
using BiddingSystem.Entities;

namespace BiddingSystem.Repository.Contracts
{
    public interface IContactRepository
    {
         (int contactID, DatabaseCode dbCode) Insert(Contact contact);
    }
}
using BiddingSystem.Common;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Models.Account;
using BiddingSystem.Repository.Contracts;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IContactMapper contactMapper;
        public ContactService(IContactRepository contactRepository, IContactMapper contactMapper)
        {
            this.contactRepository = contactRepository;
            this.contactMapper = contactMapper;
        }

        public (int contactID, DatabaseCode dbCode) CreateContact(ContactModel contact)
        {
            return contactRepository.Insert(contactMapper.ToEntity(contact));
        }
    }
}
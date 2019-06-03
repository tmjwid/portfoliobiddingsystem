using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Entities;
using BiddingSystem.Models.Account;

namespace BiddingSystem.DTOMapper
{
    public class ContactMapper : IContactMapper
    {
        public Contact ToEntity(ContactModel contactModel)
        {
            Contact contact = new Contact();
            contact.firstname = contactModel.FirstName;
            contact.id = contactModel.ID;
            contact.jobtitle = contactModel.JobTitle;
            contact.lastname = contactModel.LastName;
            contact.middlename = contactModel.MiddleName;
            contact.phonenumber = contactModel.PhoneNumber;
            contact.secondaryphonenumber = contactModel.SecondaryPhoneNumber;
            contact.userid = contactModel.UserID;
            contact.companyid = contactModel.CompanyID;
            return contact;
        }

        public ContactModel ToModel(Contact contact)
        {
            ContactModel contactModel = new ContactModel();
            contactModel.FirstName = contact.firstname;
            contactModel.ID = contact.id;
            contactModel.JobTitle = contact.jobtitle;
            contactModel.LastName = contact.lastname;
            contactModel.MiddleName = contact.middlename;
            contactModel.PhoneNumber = contact.phonenumber;
            contactModel.SecondaryPhoneNumber = contact.secondaryphonenumber;
            contactModel.UserID = contact.userid;
            contactModel.CompanyID = contact.companyid;
            return contactModel;
        }
    }
}
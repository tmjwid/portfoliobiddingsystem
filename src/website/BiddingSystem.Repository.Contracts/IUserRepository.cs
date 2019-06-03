using System;
using BiddingSystem.Common;
using BiddingSystem.Entities;
using BiddingSystem.Models;
using BiddingSystem.Models.Account;

namespace BiddingSystem.Repository.Contracts
{
    public interface IUserRepository
    {
        bool Exist(string userName);
        User GetUser(string userName);
        bool Login(User loginModel);
        DatabaseCode Insert(User RegistrationModel);
        User GetFullUser(string userName);
        Guid GetUserID(string userName);
        (Guid userID, int companyID) GetUserAndCompanyID(string userName);
    }
}
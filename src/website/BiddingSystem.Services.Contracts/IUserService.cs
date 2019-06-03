using System;
using BiddingSystem.Common;
using BiddingSystem.Models;
using BiddingSystem.Models.Account;

namespace BiddingSystem.Services.Contracts
{
    public interface IUserService
    {
        bool DoesUserExist(string userName);
        UserModel GetUser(string userName);
        bool Login(UserModel loginModel);
        DatabaseCode Register(RegistrationModel registerModel);
        UserModel GetFullUser(string name);
        Guid GetUserID(string userName);
        (Guid userID, int companyID) GetUserAndCompanyID(string userName);
    }
}
using System;
using BiddingSystem.Common;
using BiddingSystem.Models.Account;

namespace BiddingSystem.Services.Contracts
{
    public interface ICompanyService
    {
        int GetCompanyIDByUserUsername(string username);
        (int companyID, DatabaseCode dbCOde) Insert(CompanyModel company);
    }
}
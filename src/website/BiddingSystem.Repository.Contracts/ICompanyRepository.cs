using System;
using BiddingSystem.Common;
using BiddingSystem.Entities;

namespace BiddingSystem.Repository.Contracts
{
    public interface ICompanyRepository
    {
        int GetCompanyIDByUserUsername(string username);
        (int companyID, DatabaseCode dbCode) Insert(Company company);
    }
}